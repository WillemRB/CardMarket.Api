namespace CardMarket.Api.Structs
{
    public struct OrderStatus
    {
        private readonly string name;

        private readonly int id;

        public override string ToString()
        {
            return name;
        }

        private OrderStatus(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public static OrderStatus Bought
        {
            get { return new OrderStatus(1, "bought"); }
        }

        public static OrderStatus Paid
        {
            get { return new OrderStatus(2, "paid"); }
        }

        public static OrderStatus Sent
        {
            get { return new OrderStatus(4, "sent"); }
        }

        public static OrderStatus Received
        {
            get { return new OrderStatus(8, "received"); }
        }

        public static OrderStatus Lost
        {
            get { return new OrderStatus(32, "lost"); }
        }

        public static OrderStatus Cancelled
        {
            get { return new OrderStatus(128, "cancelled"); }
        }
    }
}
