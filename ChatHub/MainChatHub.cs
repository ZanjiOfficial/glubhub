using Microsoft.AspNetCore.SignalR;
namespace ChatHub
{
    public class MainChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {

            var userName = string.Empty;
            var userId = string.Empty;
            userName= Context.GetHttpContext()?.Request.Query["userName"];
            userId = Context.GetHttpContext()?.Request.Query["userId"];
            Console.WriteLine("A client connected: " + Context.ConnectionId);   
            Console.WriteLine("Brugernavn: " + userName);
            Console.WriteLine("BrugerId: " + userId);

            await Clients.Caller.SendAsync("ReceiveSystemMessage", "Du har forbindelse!");
        }

    }
}
