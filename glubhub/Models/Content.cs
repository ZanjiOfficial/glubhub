namespace glubhub.Models
{
    public abstract class Content
    {
        private string v;
        private string text;
        private string link;

        public string Type { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        protected Content(string type, string description, double weight, int id)
        {
            this.Type = type;
            this.Description = description;
            Id = id;
        }

        protected Content(string v, string text, string link, int id)
        {
            this.v = v;
            this.text = text;
            this.link = link;
            Id = id;
        }
    }
}
