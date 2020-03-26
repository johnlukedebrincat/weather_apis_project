using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherWebClient.Models
{
    [DataContract]
    class WeatherBitAPIForecastModel
    {
        [DataMember]
        public List<Unnamedobject> data;
    }

    [DataContract]
    class Unnamedobject
    {
        [DataMember]
        public string datetime { get; set; }
        [DataMember]
        public float temp { get; set; }
        [DataMember]
        public float max_temp { get; set; }
        [DataMember]
        public float min_temp { get; set; }

    }
    
}
