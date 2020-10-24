using System;
using System.Collections.Generic;
using Jil;

namespace CardMarket.Api.Entities
{
    public class OrderResponse
    {
        [JilDirective("order")]
        public IList<Order> Orders { get; set; }
    }

    public class Order
    {
        [JilDirective(Name = "idOrder")]
        public int Id { get; set; }

        [JilDirective(Name = "isBuyer")]
        public bool IsBuyer { get; set; }

        [JilDirective(Name = "seller")]
        public User Seller { get; set; }

        [JilDirective(Name = "buyer")]
        public User Buyer { get; set; }

        [JilDirective(Name = "state")]
        public OrderState State { get; set; }

        [JilDirective(Name = "shippingMethod")]
        public ShippingMethod ShippingMethod { get; set; }

        [JilDirective(Name = "trackingNumber")]
        public string TrackingNumber { get; set; }

        [JilDirective(Name = "temporaryEmail")]
        public string TemporaryEmail { get; set; }

        [JilDirective(Name = "isPresale")]
        public bool IsPresale { get; set; }

        [JilDirective(Name = "shippingAddress")]
        public Address ShippingAddress { get; set; }

        [JilDirective(Name = "articleCount")]
        public int ArticleCount { get; set; }

        [JilDirective(Name = "note")]
        public string Note { get; set; }

        [JilDirective(Name = "article")]
        public IList<Article> Articles { get; set; }

        [JilDirective(Name = "articleValue")]
        public decimal ArticleValue { get; set; }

        [JilDirective(Name = "serviceFeeValue")]
        public decimal ServiceFee { get; set; }

        [JilDirective(Name = "totalValue")]
        public decimal TotalValue { get; set; }
    }

    public class OrderState
    {
        [JilDirective(Name = "state")]
        public string State { get; set; }

        [JilDirective(Name = "dateBought")]
        public DateTime DateBought { get; set; }

        [JilDirective(Name = "datePaid")]
        public DateTime DatePaid { get; set; }

        [JilDirective(Name = "dateSent")]
        public DateTime DateSent { get; set; }

        [JilDirective(Name = "dateReceived")]
        public DateTime DateReceived { get; set; }

        [JilDirective(Name = "dateCanceled")]
        public DateTime DateCanceled { get; set; }

        [JilDirective(Name = "reason")]
        public string Reason { get; set; }

        [JilDirective(Name = "wasMergedInto")]
        public int WasMergedInto { get; set; }
    }

    public class ShippingMethod
    {
        [JilDirective(Name = "isShippingMethod")]
        public int Id { get; set; }

        [JilDirective(Name = "name")]
        public string Name { get; set; }

        [JilDirective(Name = "price")]
        public decimal Price { get; set; }

        [JilDirective(Name = "isLetter")]
        public bool IsLetter { get; set; }

        [JilDirective(Name = "isInsured")]
        public bool IsInsured { get; set; }
    }
}
