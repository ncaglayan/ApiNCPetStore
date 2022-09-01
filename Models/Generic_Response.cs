using System.Text.Json.Serialization;


namespace TesteAPINuri.Models
{
    public class Generic_Response
    {
        [JsonPropertyName("code")]
        public int code { get; set; }

        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("message")]
        public string message { get; set; }
    }
}
