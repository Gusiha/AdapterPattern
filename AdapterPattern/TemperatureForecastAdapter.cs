using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace AdapterPattern
{
    internal class TemperatureForecastAdapter : ITarget
    {
        private WeatherProvider _weatherProvider;

        public List<double> GetTemperatureForecastInfo()
        {
            string jsonpath = "$.daily";
            JObject jobject = JObject.Parse(_weatherProvider.Response);
            JToken jToken = jobject.SelectToken(jsonpath);
            Daily daily = jToken.ToObject<Daily>();

            List<double> result = new List<double>();

            result.Add(daily.Temperature2mMin[0]);
            result.Add(daily.Temperature2mMax[0]);

            return result;
        }

        public TemperatureForecastAdapter(string cityName, int countryNumber, IConfiguration configuration)
        {
            _weatherProvider = new(cityName, countryNumber, configuration);
        }

    }
}
