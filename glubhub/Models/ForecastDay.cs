using System.Text.Json.Serialization;

namespace glubhub.Models
{
    public class ForecastDay
    {
        public string Date { get; set; } = "";
        public string IconPhrase { get; set; } = "";
        public string IconUrl { get; set; } = "";
        public string MinTemp { get; set; } = "";
        public string MaxTemp { get; set; } = "";
    }

    // Rå model for OpenWeather forecast endpoint
    public class ForecastRoot
    {
        [JsonPropertyName("list")]
        public List<ForecastItem> List { get; set; } = new();
        [JsonPropertyName("cnt")]
        public int Count { get; set; }
        [JsonPropertyName("cod")]
        public string Cod { get; set; } = "";
    }

    public class ForecastItem
    {
        [JsonPropertyName("dt")]
        public long Dt { get; set; }

        [JsonPropertyName("main")]
        public MainData Main { get; set; } = new();

        [JsonPropertyName("weather")]
        public List<WeatherInfo> Weather { get; set; } = new();

        [JsonPropertyName("dt_txt")]
        public string DtTxt { get; set; } = "";
    }

    public class MainData
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }
    }

    public class WeatherInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; } = "";

        [JsonPropertyName("description")]
        public string Description { get; set; } = "";

        [JsonPropertyName("icon")]
        public string Icon { get; set; } = "";
    }

    // Simpel model til current weather (bruges hvis du også henter current weather)
    public class WeatherResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("main")]
        public MainInfo Main { get; set; } = new();

        [JsonPropertyName("wind")]
        public WindInfo Wind { get; set; } = new();
    }

    public class MainInfo
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
    }

    public class WindInfo
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }
    }
}



