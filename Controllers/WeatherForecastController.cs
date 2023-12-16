using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Globalization;
using TestLocalizer.Resourses;

namespace TestLocalizer.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IStringLocalizer<Msg> _loc;

        public WeatherForecastController(IStringLocalizer<Msg> loc)
        {
            _loc = loc;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");

            var res = _loc["hi"];

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            var res1 = _loc["hi"];

            Thread.CurrentThread.CurrentCulture = new CultureInfo("uz-UZ");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("uz-UZ");

            var res2 = _loc["hi"];

            return Ok($"{res}\n{res1}\n{res2}");
        }
    }
}