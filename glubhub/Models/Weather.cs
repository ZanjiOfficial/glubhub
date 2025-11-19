namespace glubhub.Models
{
    public class Weather
    {
        public double WindSpeed { get; set; }
        public double RainAmount { get; set; }
        public string Cloudiness { get; set; }
        public double Temperature { get; set; }
        public double AirPressure { get; set; }

        public int WeatherId { get; set; }
        public Weather(double windSpeed, double rainAmount, string cloudiness, double temperature, double airPressure, int weatherId)
        {
            WindSpeed = windSpeed;
            RainAmount = rainAmount;
            this.Cloudiness = cloudiness;
            Temperature = temperature;
            AirPressure = airPressure;
            WeatherId = weatherId;
        }
    }
}
