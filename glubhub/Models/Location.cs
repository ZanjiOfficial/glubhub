namespace glubhub.Models
{
    public class Location
    {
        public string Region { get; set; }
        public string Municipality { get; set; }
        public string City { get; set; }
        public SpotType SpotType { get; set; }
        public double CoordinatesY { get; set; }
        public double CoordinatesX { get; set; }
        public Location(string region, string municipality, string city, SpotType spotType, double coordinatesY, double coordinatesX)
        {
            Region = region;
            Municipality = municipality;
            City = city;
            SpotType = SpotType;
            CoordinatesY = coordinatesY;
            CoordinatesX = coordinatesX;
        }
    }
}
