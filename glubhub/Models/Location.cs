namespace glubhub.Models
{
    public class Location
    {
        public string Region { get; set; }
        public string Municipality { get; set; }
        public string City { get; set; }
        public string Spot { get; set; }
        public Double Coordinates { get; set; }
        public Location(string region, string municipality, string city, string spot, Double coordinates)
        {
            Region = region;
            Municipality = municipality;
            City = city;
            Spot = spot;
            Coordinates = coordinates;
        }
    }
}
