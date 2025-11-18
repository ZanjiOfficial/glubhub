namespace glubhub.Models
{
    public class Fish : Content
    {
        public string Species { get; set; }
        public string Length { get; set; }
        public double Weight { get; set; }
        public int FishId { get; set; }
        public Fish(string species, string length, double weight, int fishId)
            : base("fish", species, weight, fishId)
        {
            Species = species;
            Weight = weight;
            FishId = fishId;
            this.Length = length;
        }
    }
}
