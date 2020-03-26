using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.Endpoints
{

    class OpenWeatherMapAPIEndpoint : Endpoint
    {

        public OpenWeatherMapAPIEndpoint() :
            base("https://api.openweathermap.org/data/2.5/", "61220b3024d80b3dae1b5688e0cd6fed") { }


        //api.openweathermap.org/data/2.5/{EndpoinType}?q={city name}&appid={your api key}&units=metric
        public string getByCityNameEndpoint(string cityName)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append(getEndpointType());
            stringBuilder.Append("?q=");
            stringBuilder.Append(cityName);
            stringBuilder.Append("&appid=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=metric");
            return stringBuilder.ToString();
        }

        

    }
}
