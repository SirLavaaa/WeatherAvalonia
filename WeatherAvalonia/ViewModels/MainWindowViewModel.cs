using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using WeatherAvalonia.Servises;
using WeatherAvalonia.Models;

namespace WeatherAvalonia.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string city;

        [ObservableProperty]
        private string temperature;

        [ObservableProperty]
        private string pressure;
        
        private readonly WeatherService _weatherService = new();

        [RelayCommand]
        private async Task GetWeather()
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return;
            }

            var result = await _weatherService.GetWeatherAsync(City);

            if (result != null)
            {
                Temperature = $"Temperature: {result.Main.Temp} °C";
                Pressure = $"Pressure: {result.Main.Pressure} мм.рт.ст.";
                
            }
            else
            {
                Temperature = "City not exist";
                Pressure = "";
            }
        }
    }
}
