using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.CodeDom;

namespace WpfApp1.Services
{
    internal class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public string _apiKey { get; }

        public WeatherService()
        {
            _httpClient = new HttpClient();

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("AppSettings.json");

            _configuration = configurationBuilder.Build();
            _apiKey = _configuration["Weather:apiKey"];
        }


        public string GetWeatherByCity(string cityName)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={_apiKey}"),
                Headers =
                    {
                        { "Accept", "application/json" }
                    }
             };

            var response = _httpClient.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                var streamTask = response.Content.ReadAsStreamAsync();
                streamTask.Wait();
                using (var reader = new StreamReader(streamTask.Result))
                {
                    return reader.ReadToEnd();
                }
            }

            throw new Exception("Failed to get weather data");
        }

    }
}
