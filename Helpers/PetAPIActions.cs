using System;
using Xunit.Abstractions;
using RestSharp;
using TesteAPINuri.Models;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace TesteAPINuri.Helpers
{
    public class PetAPIActions
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

        public PetAPIActions(ITestOutputHelper output)
        {
            this.LoggerOutput = output;
        }

        //GROUP: PET
        public bool Post_UpImagePet(long id)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.PetId + $"{id}/uploadImage"); //End point link

            string filePatch = $"{Directory.GetCurrentDirectory()}/Data/havhav.jpg"; //link to the directory of the image I'm passing


            restRequest.AddHeader("Content-Type", "multipart/form-data");
            restRequest.AddFile("file", filePatch);
            restRequest.AlwaysMultipartFormData = true;
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

        public bool Post_NewPet(CreatNewPet_Request requestBody)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.NewPet);
            restRequest.AddJsonBody(JsonSerializer.Serialize(requestBody)); 

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

        //PUT UPDATE PET
        public bool Put_ModifyPet(CreatNewPet_Request requestBody)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.PUT);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.NewPet);
            restRequest.AddJsonBody(JsonSerializer.Serialize(requestBody));

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

        public List<Get_pet_Response> Get_AllPetFindByStatus(string status)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.PetFindByStatus +"?status="+status); //Endpoint link
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<List<Get_pet_Response>>(restResponse.Content);
            }
            else
            {
                LoggerOutput.WriteLine("Expected code:" + System.Net.HttpStatusCode.OK +"Actual: " +restResponse.StatusCode);
                return null;
            }
        }

        public Get_pet_Response Get_petByPetId(int id)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.PetId +id); //Endpoint link
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Get_pet_Response>(restResponse.Content);
            }
            else
            {
                LoggerOutput.WriteLine("Expected code:" + System.Net.HttpStatusCode.OK + "Actual: " + restResponse.StatusCode);
                return null;
            }
        }

        public Generic_Response Get_APIError(int invalidId)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.PetId + invalidId);
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return JsonSerializer.Deserialize<Generic_Response>(restResponse.Content);
            }
            else
            {
                Console.WriteLine("Expected: " + System.Net.HttpStatusCode.NotFound + ", but actual: " + restResponse.StatusCode); ;
                return null;
            }
        }
    }
}
