namespace glubhub.Models
{
    public class Fish : Content
    {
        public string Species { get; set; }
        public string Length { get; set; }
        public double Weight { get; set; }
        public Fish(string species, string Length, double weight, int id)
            : base("fish", species, weight, id)
        {
            Species = species;
            Weight = weight;
        }
    }
}
