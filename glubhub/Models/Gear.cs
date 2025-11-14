namespace glubhub.Models
{
    public class Gear : Content
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public Gear(string category, string description, string id)
            : base("gear", description, 0, id)
        {
            Category = category;
            Description = description;
        }
    }
}
