namespace glubhub.Models
{
    public class Picture
    {
        public string Description { get; set; }
        public string Link { get; set; } = "";
        public int PictureId { get; set; }
        public Picture(string description, string link, int pictureId)
        {
            Description = description;
            Link = link;
            PictureId = pictureId;
        }

        public Picture ()
        {
            Description = "";
            Link = "";
        }
    }
}
