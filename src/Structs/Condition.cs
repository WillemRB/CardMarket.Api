namespace CardMarket.Api.Structs
{
    public struct Condition
    {
        private readonly string id;

        private readonly string name;

        private Condition(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }

        public static Condition Mint
        {
            get { return new Condition("MT", "Mint"); }
        }

        public static Condition NearMint
        {
            get { return new Condition("NM", "Near Mint"); }
        }

        public static Condition Excellent
        {
            get { return new Condition("EX", "Excellent"); }
        }

        public static Condition Good
        {
            get { return new Condition("GD", "Good"); }
        }

        public static Condition LightPlayed
        {
            get { return new Condition("LP", "Light-played"); }
        }

        public static Condition Played
        {
            get { return new Condition("PL", "Played"); }
        }

        public static Condition Poor
        {
            get { return new Condition("PO", "Poor"); }
        }

        public static Condition FromId(string id)
        {
            var properties = typeof(Condition).GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].PropertyType == typeof(Condition))
                {
                    var condition = (Condition)properties[i].GetValue(null);
                    if (condition.id == id)
                        return condition;
                }
            }

            return NearMint;
        }
    }
}
