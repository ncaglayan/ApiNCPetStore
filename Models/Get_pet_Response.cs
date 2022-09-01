using System.Text.Json.Serialization;

namespace TesteAPINuri.Models
{
    public class Get_pet_Response
    {
        [JsonPropertyName("id")]
        public long id { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }
    }
}
