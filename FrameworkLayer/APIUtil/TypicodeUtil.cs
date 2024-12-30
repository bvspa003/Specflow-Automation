using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameworkUtilities.APIUtil
{
    public class TypicodeUtil
    {
        RestClient restClient;
        RestRequest restRequest;
        public TypicodeUtil(string url)
        {
            restClient = new RestClient(url);
        }
        public RestResponse Get(string endpoint, Dictionary<string, string> headers = null)
        {
            restRequest = new RestRequest(endpoint, Method.Get);
            if (headers != null) AddHeaders(headers);
            return restClient.Execute(restRequest);
        }

        public RestResponse Post(string endpoint, object body, Dictionary<string, string> headers = null)
        {
            restRequest = new RestRequest(endpoint, Method.Post);
            if (headers != null) AddHeaders(headers);
            restRequest.AddJsonBody(body);
            return restClient.Execute(restRequest);
        }

        public RestResponse Put(string endpoint, object body, Dictionary<string, string> headers = null)
        {
            restRequest = new RestRequest(endpoint, Method.Put);
            if (headers != null) AddHeaders(headers);
            restRequest.AddJsonBody(body);
            return restClient.Execute(restRequest);
        }

        public HttpStatusCode Delete(string endpoint, Dictionary<string, string> headers = null)
        {
            restRequest = new RestRequest(endpoint, Method.Delete);
            if (headers != null) AddHeaders(headers);
            var response = restClient.Execute(restRequest);
            return response.StatusCode;
        }

        private void AddHeaders(Dictionary<string, string> headers)
        {
            foreach (KeyValuePair<string, string> key in headers)
            {
                restRequest.AddHeader(key.Key, key.Value);
            }
        }
    }
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }
}
