using AdapterPattern;
using System.Net.Http.Json;


TemperatureForecastAdapter temperatureForecastAdapter = new TemperatureForecastAdapter();
TemperatureForecastClientClass client = new TemperatureForecastClientClass(temperatureForecastAdapter);
client.ShowTemperatures();


