using System.Collections.Generic;
using Jil;

namespace CardMarket.Api.Entities
{
    public class WantsList
    {
        [JilDirective(Name = "idWantslist")]
        public int Id { get; set; }

        [JilDirective(Name = "game")]
        public Game Game { get; set; }

        [JilDirective(Name = "name")]
        public string Name { get; set; }

        [JilDirective(Name = "itemCount")]
        public int ItemCount { get; set; }

        [JilDirective("item")]
        public List<WantsListItem> Items { get; set; }
    }
}
