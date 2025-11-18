namespace glubhub.Models
{
    public class Picture : Content
    {
        public string Description { get; set; }
        public string Link { get; set; }
        public int Id { get; set; }
        public Picture(string description, string link, int id)
            : base("picture", description, link, id)
        {
            Description = description;
            Link = link;
            Id = id;
        }
    }
}
