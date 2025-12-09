namespace ChatContracts
{
    public class ConnectedUser
    {
        public string UserId { get; set; } = default!;
        public string Email { get; set; } = string.Empty;

        public string? ConnectionId { get; set; }

        public List<ChatMessage> Messages { get; set; } = new List<ChatMessage>();  



    }
}
