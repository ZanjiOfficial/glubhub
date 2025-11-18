namespace glubhub.Models
{
    public class Tips : Content
    {
        public string Text { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        public int Id { get; set; }
        public Tips(string text, string type, string link, int id)
            : base("tips", text, link, id)
        {
            Text = text;
            Type = type;
            Link = link;
            Id = id;
        }
    }
}
