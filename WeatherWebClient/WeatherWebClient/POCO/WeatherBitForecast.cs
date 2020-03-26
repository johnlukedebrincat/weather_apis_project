using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.POCO
{
    class WeatherBitForecast
    {

        private string dateTime;
        private float temperature;

        public WeatherBitForecast(string dateTime, float temperature)
        {
            this.dateTime = dateTime;
            this.temperature = temperature;
        }

        public string getDateTime()
        {
            return dateTime;
        }

        public float getTemperature()
        {
            return temperature;
        }
        
    }
}
