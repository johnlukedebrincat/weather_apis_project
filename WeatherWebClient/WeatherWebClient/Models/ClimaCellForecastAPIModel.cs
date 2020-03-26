using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherWebClient.Models
{

    [DataContract]
    class ClimaCellForecastAPIModel
    {
        [DataMember]
        public List<Unnamedobject1> data;
    }

    [DataContract]
    class Unnamedobject1
    {
        [DataMember]
        public Temp1 temp { get; set; }
        [DataMember]
        public Time observation_time { get; set; }
    }


    [DataContract]
    class Temp1
    {
        [DataMember]
        public Min min { get; set; }
        [DataMember]
        public Max max { get; set; }
    }


    [DataContract]
    class Max
    {
        [DataMember]
        public float value { get; set; }
    }

    [DataContract]
    class Min
    {
        [DataMember]
        public float value { get; set; }
    }

    [DataContract]
    class Time
    {
        [DataMember]
        public string value { get; set; }
    }
}
