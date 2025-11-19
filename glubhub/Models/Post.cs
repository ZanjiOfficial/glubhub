namespace glubhub.Models
{
    public class Post
    {
        public string Comment { get; set; }
        public Location Location { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }

        public Post(string comment, string content, int postId)
        {
            Comment = comment;
            Content = content;
            PostId = postId;
        }
    }
}



