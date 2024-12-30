using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameworkUtilities.APIUtil
{
    public class JokeGeneratorUtil
    {
        private RestClient restClient;

        public JokeGeneratorUtil(string url)
        {
            restClient = new RestClient(url);
        }

        public T Get<T>(string endpoint, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null)
        {
            var restRequest = new RestRequest(endpoint, Method.Get);
            if (headers != null) AddHeaders(restRequest, headers);
            if (parameters != null) AddParameters(restRequest, parameters);
            var response = restClient.Execute(restRequest);
            Console.WriteLine($"Response: {response.Content}");
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        private void AddHeaders(RestRequest restRequest, Dictionary<string, string> headers)
        {
            foreach (var key in headers)
            {
                restRequest.AddHeader(key.Key, key.Value);
            }
        }

        private void AddParameters(RestRequest restRequest, Dictionary<string, string> parameters)
        {
            foreach (var key in parameters)
            {
                restRequest.AddParameter(key.Key, key.Value);
            }
        }
    }
}
