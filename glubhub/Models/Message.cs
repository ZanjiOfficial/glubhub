namespace glubhub.Models
{
    public class Message
    {
        public int RecipentId { get; set; }
        public int SenderId { get; set; }
        public string Content { get; set; }
        public SeenStatus Status { get; set; }
        public int MessageId { get; set; }

        public Message() { }
        public Message(int recipentId, int senderId, SeenStatus status, int messageId, string content)
        {
            RecipentId = recipentId;
            SenderId = senderId;
            Status = status;
            MessageId = messageId;
            Content =  content;
        }
    }
}
