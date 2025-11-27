using Microsoft.AspNetCore.SignalR;
namespace ChatHub
{
    public class MainChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("A client connected: " + Context.ConnectionId);   

            return base.OnConnectedAsync();
        }

    }
}
