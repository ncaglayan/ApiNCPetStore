using System.Text.Json.Serialization;

namespace TesteAPINuri.Models
{
    public class Get_AllStoreInventory_Response
    {
        [JsonPropertyName("totvs")]
        public int totvs { get; set; }

        [JsonPropertyName("string")]
        public int string1 { get; set; }

        [JsonPropertyName("pending")]
        public int pending { get; set; }

        [JsonPropertyName("available")]
        public int available { get; set; }

        [JsonPropertyName("Not Available")]
        public int notAvailable { get; set; }

        [JsonPropertyName("dead")]
        public int dead { get; set; }

        [JsonPropertyName("non-available")]
        public int nonAvailable { get; set; }

        [JsonPropertyName("$(Data Source#status}")]
        public int dataSource { get; set; }

        [JsonPropertyName("Unavailable")]
        public int unavailable { get; set; }

        [JsonPropertyName("Sold out")]
        public int soldOut { get; set; }

        [JsonPropertyName("free")]
        public int free { get; set; }

        [JsonPropertyName("Not for sale")]
        public int notForSale { get; set; }

        [JsonPropertyName("sold")]
        public int sold { get; set; }

        [JsonPropertyName("\"sold\"")]
        public int barraSold { get; set; }

        [JsonPropertyName("dsda")]
        public int dsda { get; set; }

        [JsonPropertyName("For Sale")]
        public int forSale { get; set; }

        [JsonPropertyName("Nonavailable")]
        public int nonavailable { get; set; }

        [JsonPropertyName("avalible")]
        public int avalible { get; set; }

        [JsonPropertyName("Open for Sale")]
        public int openForSale { get; set; }

        [JsonPropertyName("Sweetest petty in the world!")]
        public int sweetest { get; set; }

        [JsonPropertyName("brown")]
        public int brown { get; set; }

        [JsonPropertyName("AVAILABLE")]
        public int available1 { get; set; }

        [JsonPropertyName("connector_up")]
        public int connector { get; set; }

        [JsonPropertyName("Not For sale")]
        public int notForSale1 { get; set; }

        [JsonPropertyName("status")]
        public int status { get; set; }
    }
}
