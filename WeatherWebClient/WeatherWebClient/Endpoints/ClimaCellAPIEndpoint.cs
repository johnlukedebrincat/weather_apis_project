using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.Endpoints
{
    class ClimaCellAPIEndpoint : Endpoint
    {
        public ClimaCellAPIEndpoint() :
           base("https://api.climacell.co/v3/weather/",
           "P5XDCF5gjzhWv5ZSDqtOQzFdOS8oRHrG")
        { }

        //https:/api.climacell.co/v3/weather/realtime?apikey={your api key}&lat={LATITUDE}&lon={LONGITUDE}&fields=temp:C
        public string getWeatherEndpoint(float latitude, float longitude)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("realtime?apikey=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&lat=");
            stringBuilder.Append(latitude);
            stringBuilder.Append("&lon=");
            stringBuilder.Append(longitude);
            stringBuilder.Append("&fields=temp:C");
            return stringBuilder.ToString();

        }


        //https:/api.climacell.co/v3/weather/forecast/daily?apikey={your api key}&lat={LATITUDE}&lat={LONGITUDE}2&start_time=now&end_time={END TIME IN THE FORMAT 2020-03-25T14:09:50Z}&fields=temp:C
        public string getForecastEndpoint(float latitude, float longitude, string time)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("forecast/daily?apikey=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&lat=");
            stringBuilder.Append(latitude);
            stringBuilder.Append("&lat=");
            stringBuilder.Append(longitude);
            stringBuilder.Append("2&start_time=now&end_time=");
            stringBuilder.Append(time);
            stringBuilder.Append("&fields=temp:C");
            return stringBuilder.ToString();

        }

    }
}
