namespace glubhub.Models
{
    public class Weather
    {
        public double WindSpeed { get; set; }
        public double RainAmount { get; set; }
        public string Cloudiness { get; set; }
        public double Temperature { get; set; }
        public double AirPressure { get; set; }
        public Weather(double windSpeed, double rainamount, string cloudiness, double temperature, double airPressure)
        {
            WindSpeed = windSpeed;
            RainAmount = rainamount;
            this.Cloudiness = cloudiness;
            Temperature = temperature;
            AirPressure = airPressure;
        }
    }
}
