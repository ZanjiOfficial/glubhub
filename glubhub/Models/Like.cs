namespace glubhub.Models
{
    public class Like
    {
        public int LikeId { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; } = default!;
        public Guid UserId { get; set; }

    }
}
