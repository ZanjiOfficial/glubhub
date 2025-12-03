namespace glubhub.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public Guid UserId { get; set; }

        public string Comment { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }

        public Location? Location { get; set; }

        public int? FishId { get; set; }
        public Fish? Fish { get; set; }

        public int? GearId { get; set; }
        public Gear Gear { get; set; }

        public int? TipsId { get; set; }
        public Tips? Tips { get; set; }

        public int? PictureId { get; set; }
        public Picture? Picture { get; set; }
        public int? TechniqueId { get; set; }
        public Technique? Technique { get; set; }
        public Comments? CommentsId { get; set; }
        public string? TechniqueTags { get; set; }
        public string? GearTags { get; set; }

        public ICollection<Comments> Comments { get; set; } = new List<Comments>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();


        public bool IsLikedByCurrentUser { get; set; }

        public int LikeCount { get; set; }


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



