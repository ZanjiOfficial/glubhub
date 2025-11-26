using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using glubhub.Models;
using glubhub.Persistent.Interfaces;
namespace glubhub.Hubs;

[Authorize] // så kun loggede ind brugere har adgang.
public class ChatHub : Hub
{
   private readonly IMessageRepository<Message> _messageRepository;

    public ChatHub(IMessageRepository<Message> messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task SendMessageToUser(string recipientId, string content)
    {
        var senderId = Context.UserIdentifier;


        if (string.IsNullOrEmpty(senderId))
        {
            throw new HubException("Unauthorized user.");
        }



        var message = new Message(senderId, recipientId, content);
        await _messageRepository.AddSync(message);
        await _messageRepository.SaveChangesAsync();




        // Send to recipient
        await Clients.User(recipientId).SendAsync("ReceiveMessage",
            senderId, content, message.MessageId, message.CreatedAt);




        // Send confirmation to sender (use MessageSent, not ReceiveMessage)
        await Clients.Caller.SendAsync("MessageSent",
            recipientId, content, message.MessageId, message.CreatedAt);
    }




    public async Task JoinUserGroup(string userId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"User_{userId}");
    }




    public async Task MarkMessagAsRead(int messageId)
    {
        var message = await _messageRepository.GetByIdAsync(messageId);
        if(message != null && message.RecipientId == Context.UserIdentifier)
        {
            message.Status = SeenStatus.Seen;
            _messageRepository.Update(message);
            await _messageRepository.SaveChangesAsync();

            //notificer sender om at beskeden er læst
            await Clients.User(message.SenderId).SendAsync("MessageRead", messageId);
        }
    }



    public override async Task OnConnectedAsync()
    {
        var userId = Context.UserIdentifier;
        if (!string.IsNullOrEmpty(userId))
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"User_{userId}");
        }
        await base.OnConnectedAsync();
    }



    public override async Task OnDisconnectedAsync(Exception exception)
    {
        var userId = Context.UserIdentifier;
        if (!string.IsNullOrEmpty(userId))
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"User_{userId}");
        }
        await base.OnDisconnectedAsync(exception);
    }
}
