using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaidStand
{
    class Weather
    {
        public List<string> weatherTypes = new List<string>() { "Sunny", "Cloudy", "Rain"};
        public string forecastedWeatherType;
        public string actualWeatherType;
        public int forecastedTemperature;
        public int actualTemperature;
        public int weatherInfluence;
        Random rand = new Random();
        public Weather()
        {
            GetWeatherForecast();
            GetActualWeather();
            weatherInfluence = CalculateWeatherInfluence();
        }

        public void GetWeatherForecast()
        {
            forecastedWeatherType = weatherTypes[rand.Next(3)];
            forecastedTemperature = rand.Next(65, 96);
        }
        public void GetActualWeather()
        {
            int changeProbability = rand.Next(1, 3);
            if (changeProbability == 2)
            {
                actualWeatherType = weatherTypes[rand.Next(3)];
            }
            else
            {
                actualWeatherType = forecastedWeatherType;
            }
            actualTemperature = rand.Next((forecastedTemperature - 5), (forecastedTemperature + 5));
            if (actualWeatherType == "Cloudy")
            {
                actualTemperature -= 5;
            }
            else if (actualWeatherType == "Rain")
            {
                actualTemperature -= 10;
            }
        }
        public int CalculateWeatherInfluence()
        {
            int weatherInfluence = 0;
            if (actualWeatherType == "Sunny")
            {
                weatherInfluence += 10;
            }
            if (actualWeatherType == "Rain")
            {
                weatherInfluence -= 10;
            }
            if (actualWeatherType == "Cloudy")
            {
                weatherInfluence -= 5;
            }
            if (actualTemperature <= 70)
            {
                weatherInfluence -= 5;
            }
            if (actualTemperature < 80 && actualTemperature > 70)
            {
                weatherInfluence += 5;
            }
            if (actualTemperature < 90 && actualTemperature > 80)
            {
                weatherInfluence += 5;
            }
            return weatherInfluence;
        }
        public void DisplayWeather()
        {
            Console.WriteLine("Todays weather forecast is: {0} degrees and {1}", forecastedTemperature, forecastedWeatherType);
        }
    }
}
