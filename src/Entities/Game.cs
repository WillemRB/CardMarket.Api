using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CardMarket.Api.Entities
{
    public class GameResponse
    {
        [JsonPropertyName("game")]
        public IList<Game> Games { get; set; }
    }

    public class Game
    {
        [JsonPropertyName("idGame")]
        public int GameId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("abbreviation")]
        public string ShortName { get; set; }
    }
}
