namespace glubhub.Models
{
    public class Post
    {
        public string Comment { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }

        public Post(string comment, string location, string content)
        {
            Comment = comment;
            Location = location;
            Content = content;
        }
}
