using System;
using System.Collections.Generic;
using System.Text;
using WeatherWebClient.Endpoints;
using WeatherWebClient.JSONParser;
using WeatherWebClient.Models;
using WeatherWebClient.POCO;

namespace WeatherWebClient.Controller
{
    class ClimaCellController : Controller
    {
        private ClimaCellAPIEndpoint climaCellAPIEndpoint;
        private AccuWeatherAPIEndpoint accuWeatherAPIEndpoint;

        public ClimaCellController() : base()
        {
            this.climaCellAPIEndpoint = new ClimaCellAPIEndpoint();
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

            string response = getResponse(climaCellAPIEndpoint.getWeatherEndpoint(locationLatitude, locationLongitude));
            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<ClimaCellWeatherAPIModel> jsonParser = new JsonParser<ClimaCellWeatherAPIModel>())
            {

                ClimaCellWeatherAPIModel climaCellWeatherAPIModel = new ClimaCellWeatherAPIModel();
                climaCellWeatherAPIModel = jsonParser.parse(response);

                temperature = climaCellWeatherAPIModel.temp.value;
            }

            return temperature;
        }

        public List<ClimaCellForecast> getForecast(string cityName, string date)
        {
            List<ClimaCellForecast> forecastList = new List<ClimaCellForecast>();

            float locationLongitude = getLocationLongitude(cityName);
            float locationLatitude = getLocationLatitude(cityName);

            string response = getResponse(climaCellAPIEndpoint.getForecastEndpoint(locationLatitude, locationLongitude, date));

            System.Diagnostics.Debug.WriteLine(response);

            using (JsonParser<ClimaCellForecastAPIModel> jsonParser = new JsonParser<ClimaCellForecastAPIModel>())
            {
                ClimaCellForecastAPIModel climaCellForecastAPIModel = new ClimaCellForecastAPIModel();
                climaCellForecastAPIModel = jsonParser.parse(response);

             /*   foreach (Data dailyForecast in climaCellForecastAPIModel.data)
                {
                    forecastList.Add(new ClimaCellForecast(dailyForecast.data.time, dailyForecast.data.temperatureMax, dailyForecast.data.temperatureMin));
                }*/
            }

            return forecastList;
        }

    }
}
