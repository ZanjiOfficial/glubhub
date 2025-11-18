namespace glubhub.Models
{
    public class Technique : Content
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public double Weight { get; set; }
        public int TechniqueId { get; set; }
        public Technique(string name, string description, double weight, int techniqueId)
            : base("technique", description, weight, techniqueId)
        {
            Name = name;
            Description = description;
            Weight = weight;
            TechniqueId = techniqueId;
        }
    }
}
