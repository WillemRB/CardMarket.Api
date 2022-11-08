
using System.Text.Json.Serialization;

namespace CardMarket.Api.Entities
{
    public class Address
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("extra")]
        public string Extra { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("zip")]
        public string ZipCode { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}
