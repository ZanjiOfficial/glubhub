using Microsoft.AspNetCore.SignalR;
using ChatContracts;
namespace ChatHub
{
    public class MainChatHub : Hub
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
                _connectedUsers.Add(new ConnectedUser
                {
                    UserId = userId,
                    Email = userName,
                    ConnectionId = Context.ConnectionId
                });

            }
            
            await Clients.Caller.SendAsync("ReceiveSystemMessage", "Du har forbindelse!");
            await Clients.All.SendAsync("UpdateUserList", _connectedUsers);
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
            }
            await base.OnDisconnectedAsync(exception);
        }

    }
}
