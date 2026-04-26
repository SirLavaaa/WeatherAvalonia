using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAvalonia.Models
{
    internal class Data
    {
        [Newtonsoft.Json.JsonProperty("temp")]
        public double Temp { get; set; }

        [Newtonsoft.Json.JsonProperty("pressure")]
        public double Pressure { get; set; }
    }
}
