namespace glubhub.Models
{
    public class Picture : Content
    {
        public string Description { get; set; }
        public string Link { get; set; }
        public int PictureId { get; set; }
        public Picture(string description, string link, int pictureId)
            : base("picture", description, link, pictureId)
        {
            Description = description;
            Link = link;
            PictureId = pictureId;
        }
    }
}
