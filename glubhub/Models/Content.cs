namespace glubhub.Models
{
    public abstract class Content
    {

        public string Type { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        protected Content(string type, string description, int id)
        {
            this.Type = type;
            this.Description = description;
            Id = id;
        }

    }
}
