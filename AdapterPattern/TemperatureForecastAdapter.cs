using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdapterPattern
{
    internal class TemperatureForecastAdapter : ITarget
    {
        private WeatherProvider _weatherProvider = new WeatherProvider();

        public class Daily
        {
            //public List<string> time { get; set; }
            public List<double> temperature_2m_max { get; set; }
            public List<double> temperature_2m_min { get; set; }

        }


        public List<double> GetTemperatureForecastInfo()
        {
            string json = _weatherProvider.Response;

            var a = JsonConvert.DeserializeObject<Daily>(json);

            List<double> result = new List<double>();
            result.Add(a.temperature_2m_min[0]);
            result.Add(a.temperature_2m_max[0]);

            return result;
        }



    }
}
