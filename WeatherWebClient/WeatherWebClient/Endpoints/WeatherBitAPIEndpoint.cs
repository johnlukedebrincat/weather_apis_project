using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.Endpoints
{
    class WeatherBitAPIEndpoint : Endpoint
    {

        public WeatherBitAPIEndpoint() :
          base("http://api.weatherbit.io",
          "c405c0536f72434c801df650c091d8b8")
        { }

        /*http:/api.weatherbit.io/v2.0/forecast/daily?key={your api key}&units=M&city{city name}&country={country code}*/
        public string getForecastEndpoint(string city, string countryCode)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/v2.0");
            stringBuilder.Append("/forecast");
            stringBuilder.Append("/daily?key=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=M&city=");
            stringBuilder.Append(city);
            stringBuilder.Append("&country=");
            stringBuilder.Append(countryCode);

            return stringBuilder.ToString();
        }


        /*http:/api.weatherbit.io/v2.0/current?key={your api key}&units=M&city{city name}&country={country code}*/
        public string getCurrentWeatherEndpoint(string city, string countryCode)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/v2.0");
            stringBuilder.Append("/current?key=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=M&city=");
            stringBuilder.Append(city);
            stringBuilder.Append("&country=");
            stringBuilder.Append(countryCode);
            return stringBuilder.ToString();

        }
        


    }
}
