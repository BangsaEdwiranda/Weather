using Xtramile.Models;
using Xtramile.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Xtramile.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherService;

        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(int? countryId, int? cityId)
        {
            if (countryId.HasValue && cityId.HasValue)
            {
                return await ExtendedWeather(countryId.Value, cityId.Value);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ExtendedWeather(int countryId, int cityId)
        {
            var model = new WeatherViewModel();

            try
            {
                model.Weathers = await _weatherService.GetWeatherList(countryId, cityId);
            }
            catch
            {
                return View("Error");
            }

            return View("ExtendedWeather", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier });
        }
    }
}
