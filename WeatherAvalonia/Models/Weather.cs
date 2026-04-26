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
    }

    public class MainWeatherInfo
    {
        [Newtonsoft.Json.JsonProperty("temp")]
        public double Temp { get; set; }

        [Newtonsoft.Json.JsonProperty("pressure")]
        public double Pressure { get; set; }
    }
}
