using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.Endpoints
{
    class DarkSkyAPIEndpoint : Endpoint
    {
        public DarkSkyAPIEndpoint() :
          base("https://api.darksky.net",
          "bc0a3673b445b397b86ac026d2c13453")
        { }
            
        //https:/api.darksky.net/forecast/[key]/[latitude],[longitude]?units=si
        public string getWeatherEndpoint(float latitude, float longitude)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/forecast");
            stringBuilder.Append("/");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("/");
            stringBuilder.Append(latitude);
            stringBuilder.Append(",");
            stringBuilder.Append(longitude);
            stringBuilder.Append("?units=si");
            return stringBuilder.ToString();

        }



    }
}
