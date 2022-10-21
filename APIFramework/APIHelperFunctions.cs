using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework
{
    public class APIHelperFunctions<T>
    {
        public RestClient client;
        public RestRequest request;
        public string baseUrl = "https://reqres.in/";

        public RestClient SetUrl(string path)
        {
            var url = Path.Combine(baseUrl, path);
            var client = new RestClient(url);
            
            return client;
        }

        public RestRequest CreateGetRequest()
        {
            var request = new RestRequest()
            {
                Method = Method.Get
            };
            request.AddHeaders(new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                { "Accept", "application/json" }
            });
            
            return request;
        }

        public RestRequest CreatePostRequest(string payload)
        {
            var request = new RestRequest()
            {
                Method = Method.Post
            };
            request.AddHeader("Content-Type", "application/json")
                   .AddJsonBody(payload);
            
            return request;
        }

        public RestRequest CreatePullRequest<T>(string payload)
        {
            var request = new RestRequest()
            {
                Method = Method.Put
            };
            request.AddHeader("Content-Type", "application/json")
                   .AddJsonBody(payload);
            
            return request;
        }

        public RestRequest CreateDeletionRequest()
        {
            request = new RestRequest()
            {
                Method = Method.Delete
            };
            request.AddHeader("Accept", "Application/json");
            
            return request;
        }

        public RestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DTO GetContent<DTO>(RestResponse response)
        {
            var content = response.Content;
            DTO dtoObject = JsonConvert.DeserializeObject<DTO>(content);
            
            return dtoObject;
        }

        public async Task<RestResponse> GetResponseAsync(RestClient restClient, RestRequest restRequest)
        {
            return await restClient.ExecuteAsync(restRequest);
        }

        public string SerializeToJson(dynamic stringContent)
        {
            string serializeObject = JsonConvert.SerializeObject(stringContent, Formatting.Indented);
            
            return serializeObject;
        }
    }
}
