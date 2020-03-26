using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherWebClient.Models
{
    [DataContract]
    class AccuWeatherAPILocationModel
    {
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public Geoposition GeoPosition { get; set; }

    }

    [DataContract]
    class Geoposition
    {
        [DataMember]
        public float Latitude { get; set; }
        [DataMember]
        public float Longitude { get; set; }
    }
}
