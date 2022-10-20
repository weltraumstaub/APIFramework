using RestSharp;
using Newtonsoft.Json;
using APIFramework.Models;

namespace APIFramework
{
    public class APISetup<T>
    {
        public ListOfUsersDTO GetUsers(string path)
        {
            var user = new APIHelperFunctions<ListOfUsersDTO>();
            var url = user.SetUrl(path);
            var request = user.CreateGetRequest();
            var response = user.GetResponse(url, request);
            ListOfUsersDTO content = user.GetContent<ListOfUsersDTO>(response);
            return content;


        }

        public PostUserDTO CreateUserObject(string path, dynamic payload)
        {
            var user = new APIHelperFunctions<PostUserDTO>();
            var url = user.SetUrl(path);
            var request = user.CreatePostRequest(payload);
            var response = user.GetResponse(url, request);
            PostUserDTO content = user.GetContent<PostUserDTO>(response);
            return content;
        }

    }
}