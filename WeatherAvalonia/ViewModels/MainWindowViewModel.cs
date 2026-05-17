using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using WeatherAvalonia.Servises;
using WeatherAvalonia.Models;
using System.Collections.Generic;

namespace WeatherAvalonia.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string city;

        [ObservableProperty]
        private string main;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string temperature;

        [ObservableProperty]
        private string pressure;

        [ObservableProperty]
        private string feelsLike;

        [ObservableProperty]
        private string speed;

        [ObservableProperty]
        private string gust;

        private readonly List<string> _facts = new()
        {
            "Мировой рекорд самого быстрого изменения температуры зафиксирован в США (штат Южная Дакота) в 1943 году. Всего за 2 минуты воздух прогрелся с -20°C до +7°C.",
            "Невинные пушистые белые облака на самом деле весят невероятно много. Среднее кучевое облако тянет примерно на 500 тонн",
            "В некоторых регионах мира выпадали дожди розового, красного или черного цвета. Чаще всего это связано с тем, что ветер поднимает в воздух пыль или пыльцу растений из других областей.",
            "В жаркой Сахаре периодически выпадает снег, который иногда лежит несколько часов, прежде чем растаять.",
            "По данным National Geographic, каждую минуту на нашей планете происходит около 2000 гроз.",
            "В Сухих долинах Мак-Мердо в Антарктиде осадков не было уже около 2 миллионов лет. Местный ландшафт абсолютно свободен от льда и снега.",
            "Метеорология - наука изучающая погоду и климат является самой молодой естественной наукой в мире.",
            "Самое солнечное место на Земле - это Мёртвое Море и его окрестности. В году там довольно часто бывает около 330 солнечных дней.",
            "Самый быстрый ветер был зарегистрирован в американском штате Оклахома и его скорость составляла 512 километров в час.",
            "Самое дождливое место на Земле - это гора Уаи-Аль-Аль на Гавайских островах. В среднем там наблюдается 350 дождливых дней в году.",
            "В 1816 году в Северной Америке снег шёл 12 месяцев подряд.",
            "Зимой 1932 года Ниагарский водопад в США полностью замёрз.",
            "самое не солнечное место на Земле - это архипелаг Северная Земля, который находится за полярным кругом. Там в среднем только 12 солнечных дней в году.",
            "Веллингтон, расположенный в Новой Зеландии, считается городом ветров. Около 22 дней в году их скорость превышает 20,5 м/сек, а еще 173 дня – 16 м/сек."
        };

        private readonly Random _rnd = new Random();

        [ObservableProperty]
        private string _fact;

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
                Main = $"Main: {result.Weather[0].Main}";
                Description = $"Description: {result.Weather[0].Description}";
                Temperature = $"Temperature: {result.Main.Temp} °C";
                Pressure = $"Pressure: {result.Main.Pressure} мм.рт.ст.";
                FeelsLike = $"Feels Like: {result.Main.FeelsLike} °C";
                Speed = $"Wind speed: {result.Wind.Speed} м/с";
                Gust = $"Wind gust: {result.Wind.Gust} м/с";
                int index = _rnd.Next(_facts.Count);
                Fact = $"Интересный факт: {_facts[index]}";
            }
            else
            {
                Main = "City not found";
                Description = null;
                Temperature = null;
                Pressure = null;
                FeelsLike = null;
                Speed = null;
                Gust = null;
                Fact = null;
            }
        }
    }
}
