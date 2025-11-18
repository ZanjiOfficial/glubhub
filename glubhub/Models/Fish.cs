namespace glubhub.Models
{
    public class Fish
    {
        public string Species { get; set; }
        public int Length { get; set; }
        public double Weight { get; set; }
        public int FishId { get; set; }
        public Fish(string species, int length, double weight, int fishId)
        {
            Species = species;
            Weight = weight;
            FishId = fishId;
            this.Length = length;
        }
    }
}
