using System.Text.Json.Serialization;

namespace CardMarket.Api.Entities
{
    public class User
    {
        [JsonPropertyName("idUser")]
        public int Id { get; set; }

        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("isCommercial")]
        public int IsCommercial { get; set; }

        [JsonPropertyName("riskGroup")]
        public int RiskGroup { get; set; }

        [JsonPropertyName("reputation")]
        public int Reputation { get; set; }

        [JsonPropertyName("shipsFast")]
        public int ShipsFast { get; set; }

        [JsonPropertyName("sellCount")]
        public int SellCount { get; set; }

        [JsonPropertyName("onVacation")]
        public bool OnVacation { get; set; }

        [JsonPropertyName("idDisplayLanguage")]
        public string DisplayLanguage { get; set; }

        [JsonPropertyName("name")]
        public UserName Name { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }
    }

    public class UserName
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
    }
}
