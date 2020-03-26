using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherWebClient.Models
{
    [DataContract]
    class WeatherBitAPIWeatherModel
    {
        [DataMember]
        public Data data { get; set; }
    }

    [DataContract]
    class Data
    {
        [DataMember]
        public float temp { get; set; }
    }
}
