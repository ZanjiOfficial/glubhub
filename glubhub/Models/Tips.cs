namespace glubhub.Models
{
    public class Tips : Indhold
    {
        public string Text { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        public Tips(string text, string type, string link, string id)
            : base("tips", text, link, id)
        {
            Text = text;
            Type = type;
            Link = link;
        }
    }
}
