using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAvalonia.Servises
{
    internal class WeatherService
    {
        private readonly HttpClient _httpClient = new();

        private const string ApiKey = "601f11387b007836cf77827c9bf290b9";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public async Task<Models.WeatherModel> GetWeatherAsync(string city)
        {
            string url = $"{BaseUrl}?q={city}&units=metric&appid={ApiKey}&lang=ru";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Models.WeatherModel>(json);
        }
    }
}
