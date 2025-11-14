namespace glubhub.Models
{
    public abstract class Indhold
    {
        private string v;
        private string text;
        private string link;

        public string type { get; set; }
        public string beskrivelse { get; set; }
        public string Id { get; set; }
        protected Indhold(string type, string beskrivelse, double weight, string id)
        {
            this.type = type;
            this.beskrivelse = beskrivelse;
            Id = id;
        }

        protected Indhold(string v, string text, string link, string id)
        {
            this.v = v;
            this.text = text;
            this.link = link;
            Id = id;
        }
    }
}
