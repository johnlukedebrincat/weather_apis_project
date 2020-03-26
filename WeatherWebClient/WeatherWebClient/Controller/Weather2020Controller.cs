using System;
using System.Collections.Generic;
using System.Text;
using WeatherWebClient.Endpoints;
using WeatherWebClient.JSONParser;
using WeatherWebClient.Models;
using WeatherWebClient.POCO;

namespace WeatherWebClient.Controller
{
    class Weather2020Controller : Controller
    {
        private Weather2020APIEndpoint weather2020APIEndpoint;
        private AccuWeatherAPIEndpoint accuWeatherAPIEndpoint;

        public Weather2020Controller() : base()
        {
            this.weather2020APIEndpoint = new Weather2020APIEndpoint();
            this.accuWeatherAPIEndpoint = new AccuWeatherAPIEndpoint();
        }

        private float getLocationLongitude(string cityName)
        {
            float locationLongitude;

            string response = getResponse(accuWeatherAPIEndpoint.getLocationEndpoint(cityName));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<List<AccuWeatherAPILocationModel>> jsonParser = new JsonParser<List<AccuWeatherAPILocationModel>>())
            {

                List<AccuWeatherAPILocationModel> accuWeatherModel = new List<AccuWeatherAPILocationModel>();
                accuWeatherModel = jsonParser.parse(response);
                locationLongitude = accuWeatherModel[0].GeoPosition.Longitude;
            }

            return locationLongitude;
        }

        private float getLocationLatitude(string cityName)
        {
            float locationLatitude;

            string response = getResponse(accuWeatherAPIEndpoint.getLocationEndpoint(cityName));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<List<AccuWeatherAPILocationModel>> jsonParser = new JsonParser<List<AccuWeatherAPILocationModel>>())
            {

                List<AccuWeatherAPILocationModel> accuWeatherModel = new List<AccuWeatherAPILocationModel>();
                accuWeatherModel = jsonParser.parse(response);
                locationLatitude = accuWeatherModel[0].GeoPosition.Latitude;
            }

            return locationLatitude;
        }

        public List<Weather2020Forecast> getForecast(string cityName)
        {
            List<Weather2020Forecast> forecastList = new List<Weather2020Forecast>();

            float locationLongitude = getLocationLongitude(cityName);
            float locationLatitude = getLocationLatitude(cityName);

            string response = getResponse(weather2020APIEndpoint.getWeather2020Endpoint(locationLatitude, locationLongitude));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<Weather2020Model> jsonParser = new JsonParser<Weather2020Model>())
            {
                Weather2020Model weather2020Model = new Weather2020Model();
                weather2020Model = jsonParser.parse(response);

                foreach (Weather2020Model dailyForecast in weather2020Model)
                {
                    forecastList.Add(new Weather2020Forecast(dailyForecast.startDate, dailyForecast.temperatureHighCelcius, dailyForecast.temperatureLowCelcius));
                }
            }

            return forecastList;
        }
    }
}
