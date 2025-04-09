using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cars.Service
{
    internal class CarsService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public async Task<string> GetVehicleDataAsync(string make, string model)
        {
            var requestUrl = $"https://public.opendatasoft.com/api/explore/v2.1/catalog/datasets/all-vehicles-model/records?limit=20&refine=model%3A%22{model}%22&refine=make%3A%22{make}%22";
            var response = await _httpClient.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
    
            throw new Exception("Failed to get vehicle data");
        }



    }
}
