using System.Text.Json;
using WeatherApp.Models;

namespace WeatherApp.ApiService
{
    public static class ApiService
    {
        private static string apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY", EnvironmentVariableTarget.User)
            ?? throw new Exception("API key not found.");

        private static HttpClient _httpClient = new HttpClient();

        private static string BuildQuery(string city)
        {
            return $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{city}?unitGroup=us&key={apiKey}";
        }

        public async static Task<Forecast> GetApiData(string city)
        {
            string query = BuildQuery(city);

            HttpResponseMessage result = await _httpClient.GetAsync(query);

            result.EnsureSuccessStatusCode();

            string content = await result.Content.ReadAsStringAsync();
            return ParseData(content);
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
