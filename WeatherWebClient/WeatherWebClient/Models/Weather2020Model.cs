using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherWebClient.Models
{
    [CollectionDataContract]
    class Weather2020Model: List<Weather2020Model>
    {
        [DataMember]
        public long startDate { get; set; }
        [DataMember]
        public float temperatureHighCelcius { get; set; }
        [DataMember]
        public float temperatureLowCelcius { get; set; }

       
    }

  
}
