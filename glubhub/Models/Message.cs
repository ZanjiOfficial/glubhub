using glubhub.Data;
using System.ComponentModel.DataAnnotations;

namespace glubhub.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [Required]
        public string SenderId { get; set; } // Use string for Identity UserId
        [Required]
        public string RecipientId { get; set; } // Fixed typo
        [Required]
        public string Content { get; set; }
        public SeenStatus Status { get; set; } = SeenStatus.Unseen;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Recipient { get; set; }

        public Message() { }

        public Message(string senderId, string recipientId, string content)
        {
            SenderId = senderId;
            RecipientId = recipientId;
            Content = content;
        }
    }
}
