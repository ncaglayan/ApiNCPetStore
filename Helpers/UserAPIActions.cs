using System;
using Xunit.Abstractions;
using RestSharp;
using TesteAPINuri.Models;
using System.Text.Json;
using System.Collections.Generic;

namespace TesteAPINuri.Helpers
{
    class UserAPIActions
    {
        private ITestOutputHelper LoggerOutput;

        public ITestOutputHelper Logger
        {
            get
            {
                return LoggerOutput;
            }
            set
            {
                LoggerOutput = value;
            }
        }

        public UserAPIActions(ITestOutputHelper output)
        {
            this.LoggerOutput = output;
        }

        public Generic_Response Post_UserWithArray(List<Post_Modify_UserByUsername_Request> requestBody)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.UserNameGet +"createWithArray");
            restRequest.AddJsonBody(JsonSerializer.Serialize(requestBody));

            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Generic_Response>(restResponse.Content);
            }
            else
            {
                return null;
            }   
        }

        public Get_Username_Response Get_Username(string username)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.UserNameGet + username);
            restResponse = restClient.Execute(restRequest);

            if(restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Get_Username_Response>(restResponse.Content);
            }
            else
            {
                LoggerOutput.WriteLine("Error, expected code:" + System.Net.HttpStatusCode.OK + " but, it was returned: " + restResponse.StatusCode);
                return null;
            }
        }

        public Generic_Response Put_UserByUserName(Put_Modify_UserByUsername_Response requestObject, string username)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.PUT);
            IRestResponse restReponse;

            restClient.BaseUrl = new Uri(APIMethods.UserNameGet +username);
            restRequest.AddJsonBody(JsonSerializer.Serialize(requestObject));

            restReponse = restClient.Execute(restRequest);

            if (restReponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Generic_Response>(restReponse.Content);
            }
            else
            {
                return null;
            }
        }

        public bool Delete_UserByUserName(string username)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.DELETE);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.UserNameGet + username);
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Generic_Response Get_login(string username, string password)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.UserLogin + "?username=" +username +"&password=" +password);
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Generic_Response>(restResponse.Content); 
            }
            else
            {
                return null;
            }
        }

        public Generic_Response Get_Logout()
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.UserLogout);
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Generic_Response>(restResponse.Content);
            }
            else
            {
                return null;
            }
        }

        public Generic_Response Post_NewUser(Post_Modify_UserByUsername_Request requestBody)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.PostUser);
            restRequest.AddJsonBody(JsonSerializer.Serialize(requestBody));

            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Generic_Response>(restResponse.Content);
            }
            else
            {
                return null;
            }
        }
    }
}
