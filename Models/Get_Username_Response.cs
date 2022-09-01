using System.Text.Json.Serialization;

namespace TesteAPINuri.Models
{
    class Get_Username_Response
    {
        [JsonPropertyName("username")]
        public string username { get; set; }
    }
}
