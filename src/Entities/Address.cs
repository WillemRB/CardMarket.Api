using Jil;

namespace CardMarket.Api.Entities
{
    public class Address
    {
        [JilDirective(Name = "name")]
        public string Name { get; set; }

        [JilDirective(Name = "extra")]
        public string Extra { get; set; }

        [JilDirective(Name = "street")]
        public string Street { get; set; }

        [JilDirective(Name = "zip")]
        public string ZipCode { get; set; }

        [JilDirective(Name = "city")]
        public string City { get; set; }

        [JilDirective(Name = "country")]
        public string Country { get; set; }
    }
}
