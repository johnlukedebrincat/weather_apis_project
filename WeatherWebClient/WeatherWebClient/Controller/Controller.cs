using System;
using System.Collections.Generic;
using System.Text;
using WeatherWebClient.Client;

namespace WeatherWebClient.Controller
{
    abstract class Controller
    {
        protected RestClient client;

        public Controller()
        {
            client = new RestClient();
        }

        protected string getResponse(string endpoint)
        {
            client.endpoint = endpoint;
            return client.makeRequest();
        }
    }
}
