using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel.Helpers
{
    public class AccuWeatherAPI
    {
        public const string API_KEY = "UE8o0ALLQM6xbAQeoaVuxWaVgTIlcRlM";
        public const string BASE_URL = "http://dataservice.accuweather.com";

        public static async Task<List<City>> AutocompleteCities(string query)
        {
            List<City> cities = new List<City>();

            string endpoint = string.Format("/locations/v1/cities/autocomplete?apikey={0}&q={1}", API_KEY, query);
            string requestUrl = BASE_URL + endpoint;
            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(requestUrl);
                string json = await response.Content.ReadAsStringAsync();
                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }

        public static async Task<Weather> GetCurrentConditions(string cityKey)
        {
            Weather weather = new Weather();

            string endpoint = string.Format("/currentconditions/v1/{0}?apikey={1}", cityKey, API_KEY);
            string requestUrl = BASE_URL + endpoint;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(requestUrl);
                string json = await response.Content.ReadAsStringAsync();
                weather = JsonConvert.DeserializeObject<List<Weather>>(json).FirstOrDefault();
            }

            return weather;
        }
    }
}
