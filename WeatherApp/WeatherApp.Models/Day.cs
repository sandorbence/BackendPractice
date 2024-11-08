namespace WeatherApp.Models
{
    public class Day
    {
        public DateTime Date { get; set; }
        public float Temp { get; set; }
        public float TempMin { get; set; }
        public float TempMax { get; set; }
        public float FeelsLike { get; set; }
        public float Humdity { get; set; }
        public string Description { get; set; }
    }
}
