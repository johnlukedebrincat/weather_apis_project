using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.POCO
{
    class ClimaCellForecast
    {

        private string time;
        private float max;
        private float min;

        public ClimaCellForecast(string time, float max, float min)
        {
            this.time = time;
            this.max = max;
            this.min = min;
        }

        public string getDateTime()
        {
            return time;
        }

        public float getTemperatureMax()
        {
            return max;
        }

        public float getTemperatureMin()
        {
            return min;
        }


    }
}
