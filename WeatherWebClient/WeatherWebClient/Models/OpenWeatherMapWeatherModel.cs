﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherWebClient.Models.Weather
{
    //only for 2017 - Add DataContract before each class and DataMember before each attribute
    [DataContract]
    class OpenWeatherMapWeatherModel
    {
        [DataMember]
        public Main main { get; set; }
    }

    [DataContract]
    class Main
    {
        [DataMember]
        public float temp { get; set; }
        [DataMember]
        public float feels_like { get; set; }
        [DataMember]
        public float temp_min { get; set; }
        [DataMember]
        public float temp_max { get; set; }
        [DataMember]
        public float pressure { get; set; }
        [DataMember]
        public float humidity { get; set; }


    }
}
