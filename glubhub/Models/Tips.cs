namespace glubhub.Models
{
    public class Tips
    {
        public string? Text { get; set; }="";
        public string? Type { get; set; }="";
        public string? Link { get; set; } = "";
        public int TipsId { get; set; }
        public Tips() { }
        public Tips(string text, string type, string link, int tipsId)
        {
            Text = text;
            Type = type;
            Link = link;
            TipsId = tipsId;
        }

    }
}
