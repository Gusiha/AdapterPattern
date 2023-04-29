namespace AdapterPattern
{
    internal class WeatherProvider
    {
        public string Response { get; set; }
        static HttpClient httpClient = new HttpClient();

        static async Task<string> GetWeatherAsync()
        {
            return await httpClient.GetStringAsync("https://api.open-meteo.com/v1/forecast?latitude=55.75&longitude=37.62&daily=temperature_2m_max,temperature_2m_min&forecast_days=1&timezone=Europe%2FMoscow");
        }

        public WeatherProvider()
        {
            Response = @"{""time"":[""2023-04-29""],""temperature_2m_max"":[11.7],""temperature_2m_min"":[2.5]}";
        }
    }
}