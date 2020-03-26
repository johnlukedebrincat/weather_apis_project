using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherWebClient.Models
{
   

    [DataContract]
    class DarkSkyAPIModel
    {
        [DataMember]
        public Currently currently { get; set; }
        [DataMember]
        public List<Daily> daily;
    }

    [DataContract]
    class Currently
    {
        [DataMember]
        public float temperature { get; set; }
    }

    [DataContract]
    class Daily
    {
        [DataMember]
        public DailyData data { get; set; }
    }

    [DataContract]
    class DailyData
    {
        [DataMember]
        public long time { get; set; }
        [DataMember]
        public float temperatureMin { get; set; }
        [DataMember]
        public float temperatureMax { get; set; }

    }
}
