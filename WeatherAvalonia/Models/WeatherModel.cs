using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAvalonia.Models
{
    internal class WeatherModel
    {
        [JsonProperty("main")]
        public MainInfo Main { get; set; }
        [JsonProperty("wind")]
        public WindInfo Wind { get; set; }
        [JsonProperty("weather")]
        public List<WeatherInfo> Weather { get; set; }
    }
    public class MainInfo
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

    public class WeatherInfo
    {
        [JsonProperty("main")]
        public string Main { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
    
}
