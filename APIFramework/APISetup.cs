using RestSharp;
using Newtonsoft.Json;
using APIFramework.Models;

namespace APIFramework
{
    public class APISetup
    {
        public ListOfUsersDTO GetUsers()
        {
            var client = new RestClient("https://reqres.in/");
            var request = new RestRequest("/api/users?page=2", Method.Get)
                                        .AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;

            var response = client.Get(request);
            var content = response.Content;

            var users = JsonConvert.DeserializeObject<ListOfUsersDTO>(content);
            return users;

        }

        
    }
}