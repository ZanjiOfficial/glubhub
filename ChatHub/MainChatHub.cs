using Microsoft.AspNetCore.SignalR;
using ChatContracts;
namespace ChatHub
{
    public class MainChatHub : Hub<IChatClient> 
    {
        private static readonly object _lock = new object();
        private static List<ConnectedUser> _connectedUsers = new List<ConnectedUser>();
        public override async Task OnConnectedAsync()
        {

            var userName = string.Empty;
            var userId = string.Empty;
            userName= Context.GetHttpContext()?.Request.Query["userName"];
            userId = Context.GetHttpContext()?.Request.Query["userId"];
            Console.WriteLine("A client connected: " + Context.ConnectionId);   
            Console.WriteLine("Brugernavn: " + userName);
            Console.WriteLine("BrugerId: " + userId);


            lock (_lock)
            {
                //Fjerne brugeren hvis den allerede eksistere, for at undgå dubletter
                _connectedUsers.RemoveAll(u => u.UserId == userId);

                _connectedUsers.Add(new ConnectedUser
                {
                    UserId = userId,
                    Email = userName,
                    ConnectionId = Context.ConnectionId
                });

            }
            
            await Clients.Caller.ReceiveSystemMessage("Du har forbindelse!");
            await Clients.All.UpdateUserList(_connectedUsers);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
          ConnectedUser? user;
            lock (_lock)
            {
                user = _connectedUsers.FirstOrDefault(u => u.ConnectionId == Context.ConnectionId);
                if (user != null)
                {
                    _connectedUsers.Remove(user);
                }
            }
            if (user != null)
            {
                Console.WriteLine("A client disconnected: " + Context.User);
                await Clients.All.UpdateUserList(_connectedUsers);
            }
            await base.OnDisconnectedAsync(exception);
        }

        public async Task ForwardMessage(string fromUserId, string toUserId, string message)
        {
            Console.WriteLine($"ForwardMessage called: from {fromUserId} to {toUserId}");

            if (!string.IsNullOrWhiteSpace(toUserId))
            {
                ConnectedUser? targetUser;
                lock (_lock)
                {
                    targetUser = _connectedUsers.FirstOrDefault(u => u.UserId == toUserId);
                }

                if (targetUser != null && !string.IsNullOrWhiteSpace(targetUser.ConnectionId))
                {
                    Console.WriteLine($"Sending message to connection: {targetUser.ConnectionId}");
                    await Clients.Client(targetUser.ConnectionId).ReceiveMessage(fromUserId, Context.ConnectionId, message);
                }
                else
                {
                    Console.WriteLine($"Target user not found or not connected: {toUserId}");
                    await Clients.Caller.ReceiveSystemMessage($"Brugeren med ID {toUserId} er ikke online.");
                }
            }
            else
            {
                Console.WriteLine("ToUserId is null or empty");
            }
        }
    }
}
