using Jil;

namespace CardMarket.Api.Entities
{
    public class User
    {
        [JilDirective(Name = "idUser")]
        public int Id { get; set; }

        [JilDirective(Name = "username")]
        public string UserName { get; set; }

        [JilDirective(Name = "country")]
        public string Country { get; set; }

        [JilDirective(Name = "isCommercial")]
        public int IsCommercial { get; set; }

        [JilDirective(Name = "riskGroup")]
        public int RiskGroup { get; set; }

        [JilDirective(Name = "reputation")]
        public int Reputation { get; set; }

        [JilDirective(Name = "shipsFast")]
        public int ShipsFast { get; set; }

        [JilDirective(Name = "sellCount")]
        public int SellCount { get; set; }

        [JilDirective(Name = "onVacation")]
        public bool OnVacation { get; set; }

        [JilDirective(Name = "idDisplayLanguage")]
        public string DisplayLanguage { get; set; }

        [JilDirective(Name = "name")]
        public UserName Name { get; set; }

        [JilDirective(Name = "address")]
        public Address Address { get; set; }
    }

    public class UserName
    {
        [JilDirective(Name = "firstName")]
        public string FirstName { get; set; }

        [JilDirective(Name = "lastName")]
        public string LastName { get; set; }
    }
}
