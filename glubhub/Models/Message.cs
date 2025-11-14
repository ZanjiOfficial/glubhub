namespace glubhub.Models
{
    public class Message
    {
        public string RecipentId { get; set; }
        public string SenderId { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public Message(string recipentId, string senderId, string content, string status)
        {
            RecipentId = recipentId;
            SenderId = senderId;
            Content = content;
            Status = status;
        }
    }
}
