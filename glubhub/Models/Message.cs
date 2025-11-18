namespace glubhub.Models
{
    public class Message
    {
        public int RecipentId { get; set; }
        public int SenderId { get; set; }
        public Content Content { get; set; }
        public SeenStatus Status { get; set; }
        public int MessageId { get; set; }
        public Message(int recipentId, int senderId, Content content, SeenStatus status, int messageId)
        {
            RecipentId = recipentId;
            SenderId = senderId;
            Content = content;
            Status = status;
            MessageId = messageId;
        }
    }
}
