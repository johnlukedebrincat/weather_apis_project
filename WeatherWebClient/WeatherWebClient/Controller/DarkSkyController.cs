using System;
using System.Collections.Generic;
using System.Text;
using WeatherWebClient.Endpoints;
using WeatherWebClient.JSONParser;
using WeatherWebClient.Models;
using WeatherWebClient.POCO;

namespace WeatherWebClient.Controller
{
    class DarkSkyController : Controller
    {
        private DarkSkyAPIEndpoint darkSkyAPIEndpoint;
        private AccuWeatherAPIEndpoint accuWeatherAPIEndpoint;

        public DarkSkyController() : base()
        {
            this.darkSkyAPIEndpoint = new DarkSkyAPIEndpoint();
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

        public float getCurrentWeather(string cityName)
        {
            float temperature = 0f;

            float locationLongitude = getLocationLongitude(cityName);
            float locationLatitude = getLocationLatitude(cityName);

            string response = getResponse(darkSkyAPIEndpoint.getWeatherEndpoint(locationLatitude, locationLongitude));
            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<DarkSkyAPIModel> jsonParser = new JsonParser<DarkSkyAPIModel>())
            {

                DarkSkyAPIModel darkSkyAPIModel = new DarkSkyAPIModel();
                darkSkyAPIModel = jsonParser.parse(response);

                temperature = darkSkyAPIModel.currently.temperature;
            }

            return temperature;
        }

        public List<DarkSkyForecast> getForecast(string cityName)
        {
            List<DarkSkyForecast> forecastList = new List<DarkSkyForecast>();

            float locationLongitude = getLocationLongitude(cityName);
            float locationLatitude = getLocationLatitude(cityName);

            string response = getResponse(darkSkyAPIEndpoint.getWeatherEndpoint(locationLatitude, locationLongitude));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<DarkSkyAPIModel> jsonParser = new JsonParser<DarkSkyAPIModel>())
            {
                DarkSkyAPIModel darkSkyAPIModel = new DarkSkyAPIModel();
                darkSkyAPIModel = jsonParser.parse(response);

                foreach (Daily dailyForecast in darkSkyAPIModel.daily)
                {
                    forecastList.Add(new DarkSkyForecast(dailyForecast.data.time, dailyForecast.data.temperatureMax, dailyForecast.data.temperatureMin));
                }
            }

            return forecastList;
        }
    }
}
