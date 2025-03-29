using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Services;
using WpfApp1.Models;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {

        private readonly WeatherService _weatherService = new WeatherService();

        public MainWindow()
        {
            InitializeComponent();
        }

        // ...

        private void GetWeather(object sender, RoutedEventArgs e)
        {
            try
            {
                var city_name = SearchBox.Text;
                var weather = _weatherService.GetWeatherByCity(city_name);
                var searchresult = JsonSerializer.Deserialize<Rootobject>(weather);
                CityName.Text = searchresult.name;
                WeatherState.Source = new BitmapImage(new Uri($"https://openweathermap.org/img/w/{searchresult.weather[0].icon}.png"));
                StateText.Text = searchresult.weather[0].description;
                Degrees.Text = (searchresult.main.temp - 273.15).ToString("F1") + " °C"; 
                MaxMinDegrees.Text = (searchresult.main.temp_max - 273.15).ToString("F1") + " °C / " + (searchresult.main.temp_min - 273.15).ToString("F1") + " °C "; 
                Humidity.Text = "Humidity: " + (searchresult.main.humidity).ToString() + " %"; 
                WindSpeed.Text = "Wind: "+(searchresult.wind.speed).ToString() + " km/h"; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " or there is no such city!");
            }
        }

    }
}
