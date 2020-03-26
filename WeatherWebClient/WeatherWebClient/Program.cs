using System;
using WeatherWebClient.Client;
using WeatherWebClient.Endpoints;
using WeatherWebClient.JSONParser;
using WeatherWebClient.Models;
using WeatherWebClient.Models.Weather;
using WeatherWebClient.Models.Forecast;
using WeatherWebClient.Controller;
using WeatherWebClient.POCO;

namespace WeatherWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //OpenWeatherMapAPI();
            //AccuWeatherAPI();
            //WeatherBitAPI();
            //DarkSkyAPI();
            Weather2020API();
            Console.ReadKey();
        }


        private static void OpenWeatherMapAPI()
        {
            string cityName = "Valletta";

            /**** Open Weather Map ****/
            /**** Current Weather ****/
            OpenWeatherMapController openWeatherMapController = new OpenWeatherMapController();

            Console.WriteLine("***** Open Weather Map *****");
            Console.WriteLine("***** Current Weather API *****");
            Console.WriteLine($"Current Temperature for {cityName}: {openWeatherMapController.getCurrentWeather(cityName)}");

            /**** FORECAST****/
            Console.WriteLine("***** Forecast API *****");
            Console.WriteLine($"Forecast for {cityName}: ");
            foreach (OpenWeatherMapForecast forecast in openWeatherMapController.getForecast(cityName))
            {
                Console.WriteLine($"{forecast.getDateTime().ToString()} Temperature: {forecast.getTemperature()}");
            }
        }

        private static void AccuWeatherAPI()
        {
            string cityName = "Valletta";

            /**** AccuWeather ****/
            /**** Current Weather ****/
            AccuWeatherController accuWeatherController = new AccuWeatherController();

            Console.WriteLine("***** AccuWeather *****");
            Console.WriteLine("***** Current Weather API *****");
            Console.WriteLine($"Current Temperature for {cityName}: {accuWeatherController.getCurrentWeather(cityName)}");

            /**** FORECAST****/
            Console.WriteLine("***** Forecast API *****");
            Console.WriteLine($"Forecast for {cityName}: ");
            foreach (AccuWeatherForecast forecast in accuWeatherController.getForecast(cityName))
            {
                Console.WriteLine($"{forecast.getDateTime().ToString()} Minimum: {forecast.getMinimum()} Maximum: {forecast.getMaximum()}");
            }

        }

        private static void WeatherBitAPI()
        {
            string city = "California";
            string countryCode = "US";
     
            /**** WeatherBit ****/
            /**** Current Weather ****/
            WeatherBitController weatherBitController = new WeatherBitController();

            Console.WriteLine("***** WeatherBit *****");
            Console.WriteLine("***** Current Weather API *****");
            Console.WriteLine($"Current Temperature for {city}, {countryCode}: {weatherBitController.getCurrentWeather(city, countryCode)}");

            /**** FORECAST****/
            Console.WriteLine("***** Forecast API *****");
            Console.WriteLine($"Forecast for {city}, {countryCode}: ");
            foreach (WeatherBitForecast forecast in weatherBitController.getForecast(city, countryCode))
            {
                Console.WriteLine($"{forecast.getDateTime().ToString()} Temp: {forecast.getTemperature()}");
            }

        }

        private static void DarkSkyAPI()
        {
            string city = "Valletta";

            /**** DarkSky ****/
            /**** Current Weather ****/
            DarkSkyController darkSkyController = new DarkSkyController();

            Console.WriteLine("***** DarkSky *****");
            Console.WriteLine("***** Current Weather API *****");
            Console.WriteLine($"Current Temperature for {city}: {darkSkyController.getCurrentWeather(city)}");

            /**** FORECAST****/
            Console.WriteLine("***** Forecast API *****");
            Console.WriteLine($"Forecast for {city}: ");
            foreach (DarkSkyForecast forecast in darkSkyController.getForecast(city))
            {
                Console.WriteLine($"{forecast.getDateTime().ToString()} Temp-High: {forecast.getTemperatureHigh()} Temp-Low: {forecast.getTemperatureLow()}");
            }

        }

        private static void Weather2020API()
        {
            string city = "Los Angeles";

            /**** Weather2020 ****/
            Weather2020Controller weather2020Controller = new Weather2020Controller();

            /**** FORECAST****/
            Console.WriteLine("***** Forecast API *****");
            Console.WriteLine($"Forecast for {city}: ");
            foreach (Weather2020Forecast forecast in weather2020Controller.getForecast(city))
            {
                Console.WriteLine($"{forecast.getDateTime().ToString()} Temp-High: {forecast.getTemperatureHigh()} Temp-Low: {forecast.getTemperatureLow()}");
            }

        }
    }
}
