using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using glubhub.Models;

public class WeatherService
{
    private readonly HttpClient _http;
    private readonly string _apiKey;

    public WeatherService(HttpClient http, IConfiguration config)
    {
        _http = http ?? throw new ArgumentNullException(nameof(http));
        // Læs fra ApiKeys:OpenWeather (typisk) og fallback til OpenWeather
        _apiKey = config["ApiKeys:OpenWeather"] ?? config["OpenWeather"] ?? "";

        // Debug: vis kun længde og sidste 4 tegn (fjern i produktion)
        Console.WriteLine($"[DEBUG] OpenWeather key loaded: len={_apiKey?.Length}, tail={(string.IsNullOrEmpty(_apiKey) ? "none" : _apiKey.Substring(Math.Max(0, _apiKey.Length - 4)))}");

        if (string.IsNullOrWhiteSpace(_apiKey))
            throw new InvalidOperationException("Missing OpenWeather API key. Set ApiKeys:OpenWeather in user-secrets or environment variables for the startup project.");
    }

    // Hjælper: bygger korrekt URL afhængig af input (city name, city id eller "lat,lon")
    private string BuildForecastUrl(string input)
    {
        if (int.TryParse(input, out var cityId))
        {
            return $"https://api.openweathermap.org/data/2.5/forecast?id={cityId}&appid={_apiKey}&units=metric&lang=da";
        }

        var parts = (input ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (parts.Length == 2
            && double.TryParse(parts[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var lat)
            && double.TryParse(parts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var lon))
        {
            return $"https://api.openweathermap.org/data/2.5/forecast?lat={lat.ToString(CultureInfo.InvariantCulture)}&lon={lon.ToString(CultureInfo.InvariantCulture)}&appid={_apiKey}&units=metric&lang=da";
        }

        return $"https://api.openweathermap.org/data/2.5/forecast?q={Uri.EscapeDataString(input ?? "")}&appid={_apiKey}&units=metric&lang=da";
    }

    // GET current weather (valgfri)
    public async Task<WeatherResponse?> GetWeatherAsync(string cityOrCoordsOrId)
    {
        try
        {
            var url = BuildCurrentUrl(cityOrCoordsOrId);
            return await _http.GetFromJsonAsync<WeatherResponse>(url);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GetWeatherAsync error: {ex.Message}");
            return null;
        }
    }

    private string BuildCurrentUrl(string input)
    {
        if (int.TryParse(input, out var cityId))
            return $"https://api.openweathermap.org/data/2.5/weather?id={cityId}&appid={_apiKey}&units=metric&lang=da";

        var parts = (input ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (parts.Length == 2
            && double.TryParse(parts[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var lat)
            && double.TryParse(parts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var lon))
        {
            return $"https://api.openweathermap.org/data/2.5/weather?lat={lat.ToString(CultureInfo.InvariantCulture)}&lon={lon.ToString(CultureInfo.InvariantCulture)}&appid={_apiKey}&units=metric&lang=da";
        }

        return $"https://api.openweathermap.org/data/2.5/weather?q={Uri.EscapeDataString(input ?? "")}&appid={_apiKey}&units=metric&lang=da";
    }

    // GET 5-day forecast — returnerer forecast-liste + fejltekst (hvis fejl)
    public async Task<(List<ForecastDay> Forecast, string? ErrorMessage)> GetForecastAsync(string cityOrCoordsOrId)
    {
        var result = new List<ForecastDay>();
        try
        {
            var url = BuildForecastUrl(cityOrCoordsOrId);
            using var resp = await _http.GetAsync(url);
            var body = await resp.Content.ReadAsStringAsync();

            if (!resp.IsSuccessStatusCode)
            {
                var msg = $"API error: {(int)resp.StatusCode} {resp.ReasonPhrase}. Body: {body}";
                Console.WriteLine(msg);
                return (result, msg);
            }

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var json = JsonSerializer.Deserialize<ForecastRoot>(body, options);
            if (json?.List == null || !json.List.Any())
                return (result, null);

            // Gruppér efter dato (dt_txt er lokal tid i API svaret)
            var groups = json.List
                .Where(x => !string.IsNullOrWhiteSpace(x.DtTxt))
                .GroupBy(x =>
                {
                    if (DateTime.TryParse(x.DtTxt, out var d)) return d.Date;
                    return DateTime.MinValue.Date;
                })
                .Where(g => g.Key != DateTime.MinValue.Date)
                .OrderBy(g => g.Key)
                .Take(5);

            foreach (var g in groups)
            {
                var noon = g.OrderBy(x =>
                    Math.Abs((DateTime.Parse(x.DtTxt) - g.Key.AddHours(12)).TotalHours)
                ).FirstOrDefault();

                if (noon == null || noon.Weather == null || !noon.Weather.Any()) continue;

                var icon = noon.Weather[0].Icon ?? "";
                var desc = noon.Weather[0].Description ?? "";

                result.Add(new ForecastDay
                {
                    Date = g.Key.ToString("yyyy-MM-dd"),
                    IconPhrase = CultureInfo.GetCultureInfo("da-DK").TextInfo.ToTitleCase(desc),
                    IconUrl = $"https://openweathermap.org/img/wn/{icon}@2x.png",
                    MinTemp = $"{Math.Round(g.Min(x => x.Main.TempMin))} °C",
                    MaxTemp = $"{Math.Round(g.Max(x => x.Main.TempMax))} °C"
                });
            }

            return (result, null);
        }
        catch (Exception ex)
        {
            var err = $"Exception in GetForecastAsync: {ex.Message}";
            Console.WriteLine(err);
            return (new List<ForecastDay>(), err);
        }
    }
}
