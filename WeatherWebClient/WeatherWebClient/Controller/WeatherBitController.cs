using System;
using System.Collections.Generic;
using System.Text;
using WeatherWebClient.Endpoints;
using WeatherWebClient.JSONParser;
using WeatherWebClient.Models;
using WeatherWebClient.POCO;

namespace WeatherWebClient.Controller
{

    class WeatherBitController : Controller
    {
        private WeatherBitAPIEndpoint weatherBitAPIEndpoint;

        public WeatherBitController() : base()
        {
            weatherBitAPIEndpoint = new WeatherBitAPIEndpoint();
        }

        public float getCurrentWeather(string city, string countryCode)
        {
            float temperature = 0f;

            string response = getResponse(weatherBitAPIEndpoint.getCurrentWeatherEndpoint(city, countryCode));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<WeatherBitAPIWeatherModel> jsonParser = new JsonParser<WeatherBitAPIWeatherModel>())
            {

                WeatherBitAPIWeatherModel weatherBitAPIWeatherModel = new WeatherBitAPIWeatherModel();
                weatherBitAPIWeatherModel = jsonParser.parse(response);

                temperature = weatherBitAPIWeatherModel.data.temp;
            }

            return temperature;
        }

        public List<WeatherBitForecast> getForecast(string city, string countryCode)
        {
            List<WeatherBitForecast> forecastList = new List<WeatherBitForecast>();

            string response = getResponse(weatherBitAPIEndpoint.getForecastEndpoint(city, countryCode));

            using (JsonParser<WeatherBitAPIForecastModel> jsonParser = new JsonParser<WeatherBitAPIForecastModel>())
            {
                WeatherBitAPIForecastModel weatherBitAPIForecastModel = new WeatherBitAPIForecastModel();
                weatherBitAPIForecastModel = jsonParser.parse(response);

                foreach (Unnamedobject unnamedObject in weatherBitAPIForecastModel.data)
                {
                    forecastList.Add(new WeatherBitForecast(unnamedObject.datetime, unnamedObject.temp));
                }
            }

            return forecastList;
        }


    }
        
}
