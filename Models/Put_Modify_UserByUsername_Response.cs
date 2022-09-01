using System.Text.Json.Serialization;

namespace TesteAPINuri.Models
{
    public class Put_Modify_UserByUsername_Response
    {
        [JsonPropertyName("id")]
        public long id { get; set; }

        [JsonPropertyName("username")]
        public string username { get; set; }

        [JsonPropertyName("firstName")]
        public string firstName { get; set; }

        [JsonPropertyName("lastName")]
        public string lastName { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("password")]
        public string password { get; set; }

        [JsonPropertyName("phone")]
        public string phone { get; set; }

        [JsonPropertyName("userStatus")]
        public int userStatus { get; set; }
    }
}
