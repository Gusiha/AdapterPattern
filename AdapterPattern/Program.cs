using AdapterPattern;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();


TemperatureForecastAdapter temperatureForecastAdapter = new TemperatureForecastAdapter("Moscow", 643, config);
TemperatureForecastClientClass client = new TemperatureForecastClientClass(temperatureForecastAdapter);
client.ShowTemperatures();


