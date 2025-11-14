namespace glubhub.Models
{
    public class Message
    {
        public int RecipentId { get; set; }
        public int SenderId { get; set; }
        public Content Content { get; set; }
        public SeenStatus Status { get; set; }
        public Message(int recipentId, int senderId, Content content, SeenStatus status)
        {
            RecipentId = recipentId;
            SenderId = senderId;
            Content = content;
            Status = status;
        }
    }
}
