using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> defaultCities = new List<string>
            {
                "Budapest",
                "London",
                "New York",
                "Sydney",
                "Buenos Aires"
            };

            List<Forecast> defaultCitiesForecast = defaultCities
                .Select(city => ApiService.ApiService.GetApiData(city).GetAwaiter().GetResult())
                .ToList();

            return View(defaultCitiesForecast);
        }

        public IActionResult City(string cityName)
        {
            Forecast forecast = ApiService.ApiService.GetApiData(cityName).GetAwaiter().GetResult();

            return View(forecast);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
