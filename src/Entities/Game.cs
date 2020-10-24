using System.Collections.Generic;
using Jil;

namespace CardMarket.Api.Entities
{
    public class GameResponse
    {
        [JilDirective(Name = "game")]
        public IList<Game> Games { get; set; }
    }

    public class Game
    {
        [JilDirective(Name = "idGame")]
        public int GameId { get; set; }

        [JilDirective(Name = "name")]
        public string Name { get; set; }

        [JilDirective(Name = "abbreviation")]
        public string ShortName { get; set; }
    }
}
