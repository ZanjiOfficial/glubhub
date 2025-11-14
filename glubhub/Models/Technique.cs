namespace glubhub.Models
{
    public class Technique : Content
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public double Weight { get; set; }
        public Technique(string name, string description, double weight, int id)
            : base("technique", description, weight, id)
        {
            Name = name;
            Description = description;
            Weight = weight;
        }
    }
}
