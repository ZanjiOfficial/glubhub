namespace glubhub.Models
{
    public class Post
    {
        public string? Comment { get; set; }
        public Location? Location { get; set; }
        public string? Content { get; set; }
        public int PostId { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        // I have made a empty default constructor for Post class -- Mikkel
        public Post()
        {
            Comment = "";
            Content = "";
        }

        public Post(string comment, string content, int postId)
        {
            Comment = comment;
            Content = content;
            PostId = postId;
        }
    }
}



