using System.Text.Json;

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using WeatherApp.ApiService.Caching;
using WeatherApp.Models;

namespace WeatherApp.ApiService
{
    public static class ApiService
    {
        private static string apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY", EnvironmentVariableTarget.User)
            ?? throw new Exception("API key not found.");

        private const string baseAddress = "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/";

        private static HttpClient _httpClient = new HttpClient();
        private static IDistributedCache _cache;
        private static ILogger _logger;

        public static void Init(IDistributedCache cache, ILogger logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public static async Task<Forecast> GetForecast(string city)
        {
            string timeStamp = DateTime.Now.ToString("yyyyMMdd_hhmm");
            string recordKey = $"{city}_{timeStamp}";

            Forecast forecast = await _cache.GetRecordAsync<Forecast>(recordKey);

            if (forecast is null)
            {
                _logger.LogInformation("Getting data from API");
                forecast = await GetApiData(city);
                await _cache.SetRecordAsync<Forecast>(recordKey, forecast);
            }
            else
            {
                _logger.LogInformation("Getting data from cache");
            }

            return forecast;
        }

        private async static Task<Forecast> GetApiData(string city)
        {
            string query = BuildQuery(city);

            HttpResponseMessage result = await _httpClient.GetAsync(query);

            result.EnsureSuccessStatusCode();

            string content = await result.Content.ReadAsStringAsync();
            return ParseData(content);
        }

        private static string BuildQuery(string city)
        {
            return $"{baseAddress}{city}?unitGroup=metric&key={apiKey}";
        }

        private static Forecast ParseData(string data)
        {
            JsonDocument doc = JsonDocument.Parse(data);
            JsonElement root = doc.RootElement;

            JsonElement daysData = root.GetProperty("days");
            List<Day> days = new List<Day>();

            foreach (JsonElement dayData in daysData.EnumerateArray())
            {
                Day day = new Day
                {
                    Date = dayData.GetProperty("datetime").GetDateTime(),
                    Temp = dayData.GetProperty("temp").GetSingle(),
                    TempMin = dayData.GetProperty("tempmin").GetSingle(),
                    TempMax = dayData.GetProperty("tempmax").GetSingle(),
                    FeelsLike = dayData.GetProperty("feelslike").GetSingle(),
                    Humidity = dayData.GetProperty("humidity").GetSingle(),
                    Description = dayData.GetProperty("description").GetString()
                };

                days.Add(day);
            }

            Forecast forecast = new Forecast
            {
                Address = root.GetProperty("address").GetString(),
                TimeZone = root.GetProperty("timezone").GetString(),
                Description = root.GetProperty("description").GetString(),
                Days = days
            };

            return forecast;
        }
    }
}
