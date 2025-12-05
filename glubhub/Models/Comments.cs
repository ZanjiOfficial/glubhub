namespace glubhub.Models
{
    public class Comments
    {
        public int CommentsId { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public string Text { get; set; } = string.Empty;

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
