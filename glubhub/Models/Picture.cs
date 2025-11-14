namespace glubhub.Models
{
    public class Picture : Indhold
    {
        public string Description { get; set; }
        public string Link { get; set; }
        public Picture(string description, string link)
            : base("picture", description, link)
        {
            Description = description;
            Link = link;
        }
    }
}
