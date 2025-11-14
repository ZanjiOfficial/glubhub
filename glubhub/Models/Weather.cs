namespace glubhub.Models
{
    public class Weather
    {
        public double WindSpeed { get; set; }
        public double Rainammount { get; set; }
        public string cloudiness { get; set; }
        public double Temperature { get; set; }
        public double AirPressure { get; set; }
        public Weather(double windSpeed, double rainammount, string cloudiness, double temperature, double airPressure)
        {
            WindSpeed = windSpeed;
            Rainammount = rainammount;
            this.cloudiness = cloudiness;
            Temperature = temperature;
            AirPressure = airPressure;
        }
    }
}
