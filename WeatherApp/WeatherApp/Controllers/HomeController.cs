using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using WeatherApp.Models;
using WeatherApp.ApiService;

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
            return View();
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
