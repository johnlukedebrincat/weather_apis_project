﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.Endpoints
{
    class Weather2020APIEndpoint : Endpoint
    {

        public Weather2020APIEndpoint() :
          base("http://api.weather2020.com",
          "e8ecee8ff60c478f8a36280fea0524fe") { }
        
        //http:/api.weather2020.com/YOURAPIKEY/LATITUDE,LONGITUDE
        public string getWeather2020Endpoint(float latitude, float longitude)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("/");
            stringBuilder.Append(latitude);
            stringBuilder.Append(",");
            stringBuilder.Append(longitude);

            return stringBuilder.ToString();

        }

    }
}
