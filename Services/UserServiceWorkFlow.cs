using TesteAPINuri.Helpers;
using Xunit;
using Xunit.Abstractions;
using TesteAPINuri.Models;
using System.Text.Json;
using System.Collections.Generic;

namespace TesteAPINuri.Services
{
    class UserServiceWorkFlow
    {
        private ITestOutputHelper LoggerOutput;

        public UserServiceWorkFlow(ITestOutputHelper LoggerOutput)
        {
            this.LoggerOutput = LoggerOutput;
        }

        public void Validate_Post_UserWithArray(object jsonInput)
        {
            List<Post_Modify_UserByUsername_Request> requestBody = JsonSerializer.Deserialize<List<Post_Modify_UserByUsername_Request>>(jsonInput.ToString());

            var response = new UserAPIActions(LoggerOutput).Post_UserWithArray(requestBody);
            Assert.True(response.code == 200);
            Assert.True(response.message == "ok");
        }

        public void Validate_GetUsername(string username)
        {
            var response = new UserAPIActions(LoggerOutput).Get_Username(username);
            Assert.NotNull(response);
            Assert.True(username == response.username, "Username: " + username + " is not equal to: " + response.username); //It's like an if else with the else after the comma
        }

        public void Validate_PutUserByUserName(object jsonInput, string username)
        {
            Put_Modify_UserByUsername_Response requestObject = JsonSerializer.Deserialize<Put_Modify_UserByUsername_Response>(jsonInput.ToString());

            var response = new UserAPIActions(LoggerOutput).Put_UserByUserName(requestObject, username);
            Assert.False(response.message == "9223372036854775807");
        }

        public void Validate_DeleteUserByUserName(string username)
        {
            var response = new UserAPIActions(LoggerOutput).Delete_UserByUserName(username);
            Assert.True(response);
        }

        public void Validate_GetUserAndPassword(string username, string password)
        {
            var response = new UserAPIActions(LoggerOutput).Get_login(username, password); //Here they receive the values of the endpoint
            Assert.True(response != null, "Get login test: Failed!");
            Assert.True(response.code == 200);
            Assert.Contains("logged in user session:", response.message);
        }

        public void Validate_GetLogout()
        {
            var response = new UserAPIActions(LoggerOutput).Get_Logout();
            Assert.True(response.code == 200);
            Assert.True(response.message == "ok");
        }

        public void Validate_PostNewUser(object jsonInput)
        {
            Post_Modify_UserByUsername_Request requestBody = JsonSerializer.Deserialize<Post_Modify_UserByUsername_Request>(jsonInput.ToString());

            var response = new UserAPIActions(LoggerOutput).Post_NewUser(requestBody);
            Assert.NotNull(response);
            Assert.True(response.code == 200, "Error, check Json file input fields");
        }
    }
}
