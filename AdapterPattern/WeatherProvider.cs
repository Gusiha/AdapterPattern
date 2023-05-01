using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace AdapterPattern
{
    internal class WeatherProvider
    {
        public string Response { get; set; }
        public string CityName { get; set; }
        public int CountryNumber { get; set; }

        private readonly IConfiguration _config;

        private readonly string _apiKey;



        private async Task<List<int>> GetCityCoords(string cityName)
        {
            List<int> list = new List<int>();
            string json;

            using (var httpClient = new HttpClient())
            {
                json = await httpClient.GetStringAsync($"http://api.openweathermap.org/geo/1.0/direct?q={CityName},{CountryNumber}&limit=1&appid={_apiKey}");
            };

            string jsonpathLantitide = "$[0].lat";
            string jsonpathLongititude = "$[0].lon";

            JArray jobject = JArray.Parse(json);
            JToken? jTockenLatitude = jobject.SelectToken(jsonpathLantitide);
            JToken? jTockenLongtitude = jobject.SelectToken(jsonpathLongititude);

            list.Add(jTockenLatitude.ToObject<int>());
            list.Add(jTockenLongtitude.ToObject<int>());

            return list;
        }

        public async Task<string> GetWeatherAsync()
        {

            List<int> geoData = new List<int>();
            geoData = await GetCityCoords(CityName);

            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync($"https://api.open-meteo.com/v1/forecast?latitude={geoData[0]}&longitude={geoData[1]}&daily=temperature_2m_max,temperature_2m_min&forecast_days=1&timezone=Europe%2FMoscow");
            } 
        }

        public WeatherProvider(string cityName, int countryNumber, IConfiguration config)
        {
            CityName = cityName;
            CountryNumber = countryNumber;
            _config = config;
            _apiKey = _config["GeoCodingApiKey"];
            Response = GetWeatherAsync().Result;
        }
    }
}