using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyLocalizedApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var cultureInfo = HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture?.Culture;
            var regionInfo = new RegionInfo(cultureInfo.LCID);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => {
                var temp = rng.Next(-20, 55);
                return new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    Temperature = regionInfo.IsMetric ? temp : (int)(temp / 0.5556),
                    TemperatureUnit = regionInfo.IsMetric ? "C" : "F",
                    Summary = Summaries[rng.Next(Summaries.Length)]
                };
            })
            .ToArray();
        }
    }
}
