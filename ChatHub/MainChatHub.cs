using Microsoft.AspNetCore.SignalR;
namespace ChatHub
{
    public class MainChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine("A client connected: " + Context.ConnectionId);   
            await Clients.Caller.SendAsync("ReceiveSystemMessage", "Du har forbindelse!");
        }

    }
}
