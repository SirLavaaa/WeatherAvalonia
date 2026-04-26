using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAvalonia.Models
{
    internal class Weather
    {
        [JsonProperty("main")]
        public MainWeatherInfo Main { get; set; }
        [JsonProperty("wind")]
        public WindInfo Wind { get; set; }
    }

    public class MainWeatherInfo
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }
    }
    public class WindInfo
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
        [JsonProperty("gust")]
        public double Gust { get; set; }
    }
}
