using RestSharp;
using Xunit.Abstractions;
using System;
using TesteAPINuri.Models;
using System.Text.Json;

namespace TesteAPINuri.Helpers
{
    class StoreAPIActions
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

        public StoreAPIActions(ITestOutputHelper output)
        {
            this.LoggerOutput = output;
        }

        public bool Post_PetOrder(Post_NewStoreOrder_Request requestBody)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.StoreOrder);
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

        //GET STORE ORDER BY ORDERID
        public Get_StoreOrder_Response Get_StoreOrderByOrderId(int orderId)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.StoreOrder + orderId);
            restResponse = restClient.Execute(restRequest);

            if(restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Get_StoreOrder_Response>(restResponse.Content);
            }
            else
            {
                LoggerOutput.WriteLine("Excepted:" + System.Net.HttpStatusCode.OK + ", Actual: " + restResponse.StatusCode);
                return null;
            }
        }

        public bool Delete_StoreOrderByOrderId(int orderId)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.DELETE);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.StoreOrder + orderId);
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                LoggerOutput.WriteLine("successfully deleted!");
                return true;
            }
            else
            {
                LoggerOutput.WriteLine("Waiting for the code:" + System.Net.HttpStatusCode.OK + ", but it was returned:" + restResponse.StatusCode);
                return false;
            }
        }

        // GET ALL STORE INVENTORY
        public Get_AllStoreInventory_Response Get_AllStoreInventory() 
        {
            
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse;

            
            restClient.BaseUrl = new Uri(APIMethods.StoreInventory);
            restResponse = restClient.Execute(restRequest);

            if(restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Get_AllStoreInventory_Response>(restResponse.Content); //Converting the contents of the json file into data
            }
            else
            {
                LoggerOutput.WriteLine("Waiting for the code:" + System.Net.HttpStatusCode.OK + ", but it was returned: " + restResponse.StatusCode);
                return null;
            }
        }
    }
}
