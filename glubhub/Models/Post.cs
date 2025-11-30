namespace glubhub.Models
{
    public class Post
    {
        public string? Comment { get; set; } = "";
        public Location? Location { get; set; }
        public string? Content { get; set; }= "";
        public int PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        // I have made a empty default constructor for Post class -- Mikkel

        // Links to other class, but they stay separate for now -- Mikkel
        public int? FishId { get; set; }
        public Fish? Fish { get; set; }

        public int? GearId { get; set; }
        public Gear? Gear { get; set; }

        public int? TechniqueId { get; set; }
        public Technique? Technique { get; set; }

        public int? TipsId { get; set; }
        public Tips? Tips { get; set; }

        public int? PictureId { get; set; }
        public Picture? Picture { get; set; }


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



