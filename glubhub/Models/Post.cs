namespace glubhub.Models
{
    public class Post
    {
        public string Comment { get; set; }
        public Location Location { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }

        public Post(string comment, Location location, string content, int postId)
        {
            Comment = comment;
            Location = location;
            Content = content;
            PostId = postId;
        }
    }
}
