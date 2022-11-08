using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CardMarket.Api.Entities
{
    public class WantsList
    {
        [JsonPropertyName("idWantslist")]
        public int Id { get; set; }

        [JsonPropertyName("game")]
        public Game Game { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("itemCount")]
        public int ItemCount { get; set; }

        [JsonPropertyName("item")]
        public List<WantsListItem> Items { get; set; }
    }
}
