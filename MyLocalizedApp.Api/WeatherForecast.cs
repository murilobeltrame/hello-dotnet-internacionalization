using System;

namespace MyLocalizedApp.Api
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        // public int TemperatureC { get; set; }
        public int Temperature { get; set; }
        public string TemperatureUnit { get; set; }

        // public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
