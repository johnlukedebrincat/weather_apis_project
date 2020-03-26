using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.POCO
{
    class DarkSkyForecast
    {

        private DateTime time;
        private float temperatureHigh;
        private float temperatureLow;

        public DarkSkyForecast(long time, float temperatureHigh, float temperatureLow)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(time);
            this.time = dateTimeOffset.UtcDateTime;
            this.temperatureHigh = temperatureHigh;
            this.temperatureLow = temperatureLow;
        }

        public DateTime getDateTime()
        {
            return time;
        }

        public float getTemperatureHigh()
        {
            return temperatureHigh;
        }

        public float getTemperatureLow()
        {
            return temperatureLow;
        }

    }
}
