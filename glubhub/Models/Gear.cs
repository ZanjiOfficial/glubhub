namespace glubhub.Models
{
    public class Gear
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public int GearId { get; set; }
        public Gear(string category, string description, int gearId)
        {
            Category = category;
            Description = description;
            GearId = gearId;
        }
    }
}
