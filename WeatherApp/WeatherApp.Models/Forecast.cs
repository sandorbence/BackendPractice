namespace WeatherApp.Models
{
    public class Forecast
    {
        public string Address { get; set; }
        public string TimeZone { get; set; }
        public string Description { get; set; }
        public List<Day> Days { get; set; }
    }
}
