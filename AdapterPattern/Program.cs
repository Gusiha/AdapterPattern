using AdapterPattern;
using System.Net.Http.Json;


TemperatureForecastAdapter temperatureForecastAdapter = new TemperatureForecastAdapter("Moscow", 643);
TemperatureForecastClientClass client = new TemperatureForecastClientClass(temperatureForecastAdapter);
client.ShowTemperatures();


