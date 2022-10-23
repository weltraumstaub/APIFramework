using RestSharp;
using Newtonsoft.Json;
using APIFramework.Models;
using System.Security.AccessControl;
using System.Reflection.Emit;

namespace APIFramework
{
    public class APISetup
    {
        private APIHelperFunctions helpers;

        public APISetup()
        {
            helpers = new APIHelperFunctions();
        }

        public RestResponse GetUsers(string path)
        {
            var url = helpers.SetUrl(path);
            var request = helpers.CreateGetRequest();
            var response = helpers.GetResponse(url, request);

            return response;
        }

        public ListOfUsersDTO GetUsersContent(dynamic response)
        {
            return helpers.GetContent<ListOfUsersDTO>(response);
        }

        public RestResponse CreateUserObject(string path, dynamic payload)
        {
            var url = helpers.SetUrl(path);
            var jsonPayload = helpers.SerializeToJson(payload);
            var request = helpers.CreatePostRequest(jsonPayload);
            var response = helpers.GetResponse(url, request);
            
            return response;
        }

        public PostUserDTO GetCreatedUserResponseBody(dynamic response)
        {
            return helpers.GetContent<PostUserDTO>(response);
        }

        public RestResponse PatchUpdateAnUserById(string path, dynamic payload)
        {
            var url = helpers.SetUrl(path);
            var jsonPayload = helpers.SerializeToJson(payload);
            var request = helpers.CreatePatchRequest(jsonPayload);
            var response = helpers.GetResponse(url, request);

            return response;
        }

        public RestResponse PutUpdateToAnUserById(string path, dynamic payload)
        {
            var url = helpers.SetUrl(path);
            var jsonPayload = helpers.SerializeToJson(payload);
            var request = helpers.CreatePutRequest(jsonPayload);
            var response = helpers.GetResponse(url, request);

            return response;
        }

        public UpdateUserDTO UpdatedUserContent(dynamic response)
        {
            return helpers.GetContent<UpdateUserDTO>(response);
        }

        public RestResponse DeleteUserById(string path)
        {
            var url = helpers.SetUrl(path);
            var request = helpers.CreateDeletionRequest();
            var response = helpers.GetResponse(url, request);

            return response;
        }

        public RestResponse RegisterNewUser(string path, dynamic payload)
        {
            var url = helpers.SetUrl(path);
            var jsonPayload = helpers.SerializeToJson(payload);
            var request = helpers.CreatePostRequest(jsonPayload);
            Console.WriteLine(request);
            var response = helpers.GetResponse(url, request);

            return response;
        }

        public RegistredUserDTO RegistredUserContent(dynamic response)
        {
            return helpers.GetContent<RegistredUserDTO>(response);
        }

    }
}