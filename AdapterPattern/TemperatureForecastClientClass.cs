using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    internal class TemperatureForecastClientClass
    {
        private ITarget _temperatureForecaster;

        public void ShowTemperatures()
        {
            var temperatures = _temperatureForecaster.GetTemperatureForecastInfo();
            Console.WriteLine($"Min temperature : {temperatures[0]}\nMax temperature : {temperatures[1]}");
        }

        public TemperatureForecastClientClass(ITarget temperatureForecaster)
        {
            _temperatureForecaster = temperatureForecaster;
        }
    }
}
