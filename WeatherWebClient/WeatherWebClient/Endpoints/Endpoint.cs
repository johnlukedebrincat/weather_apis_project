using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherWebClient.Endpoints
{
    public enum EndpointType
    {
        WEATHER,
        FORECAST
    }

    abstract class Endpoint
    {
        protected string baseEndpoint;
        protected string apiKey;
        public EndpointType endpointType { get; set; }

        public Endpoint(string baseEndpoint, string apiKey)
        {
            this.baseEndpoint = baseEndpoint;
            this.apiKey = apiKey;
        }

        protected string getEndpointType()
        {
            switch (endpointType)
            {
                case EndpointType.WEATHER:
                    return "weather";
                case EndpointType.FORECAST:
                    return "forecast";
                default:
                    return "weather";
            }
        }
    }
}

