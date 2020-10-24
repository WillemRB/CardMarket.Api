namespace CardMarket.Api.Structs
{
    public struct Actor
    {
        private readonly string name;

        private readonly int id;

        public override string ToString()
        {
            return name;
        }

        private Actor(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public static Actor Seller
        {
            get { return new Actor(1, "seller"); }
        }

        public static Actor Buyer
        {
            get { return new Actor(2, "buyer"); }
        }
    }
}
