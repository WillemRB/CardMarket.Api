using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CardMarket.Api.Entities
{
    public class OrderResponse
    {
        [JsonPropertyName("order")]
        public IList<Order> Orders { get; set; }
    }

    public class Order
    {
        [JsonPropertyName("idOrder")]
        public int Id { get; set; }

        [JsonPropertyName("isBuyer")]
        public bool IsBuyer { get; set; }

        [JsonPropertyName("seller")]
        public User Seller { get; set; }

        [JsonPropertyName("buyer")]
        public User Buyer { get; set; }

        [JsonPropertyName("state")]
        public OrderState State { get; set; }

        [JsonPropertyName("shippingMethod")]
        public ShippingMethod ShippingMethod { get; set; }

        [JsonPropertyName("trackingNumber")]
        public string TrackingNumber { get; set; }

        [JsonPropertyName("temporaryEmail")]
        public string TemporaryEmail { get; set; }

        [JsonPropertyName("isPresale")]
        public bool IsPresale { get; set; }

        [JsonPropertyName("shippingAddress")]
        public Address ShippingAddress { get; set; }

        [JsonPropertyName("articleCount")]
        public int ArticleCount { get; set; }

        [JsonPropertyName("note")]
        public string Note { get; set; }

        [JsonPropertyName("article")]
        public IList<Article> Articles { get; set; }

        [JsonPropertyName("articleValue")]
        public decimal ArticleValue { get; set; }

        [JsonPropertyName("serviceFeeValue")]
        public decimal ServiceFee { get; set; }

        [JsonPropertyName("totalValue")]
        public decimal TotalValue { get; set; }
    }

    public class OrderState
    {
        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("dateBought")]
        public DateTime DateBought { get; set; }

        [JsonPropertyName("datePaid")]
        public DateTime DatePaid { get; set; }

        [JsonPropertyName("dateSent")]
        public DateTime DateSent { get; set; }

        [JsonPropertyName("dateReceived")]
        public DateTime DateReceived { get; set; }

        [JsonPropertyName("dateCanceled")]
        public DateTime DateCanceled { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        [JsonPropertyName("wasMergedInto")]
        public int WasMergedInto { get; set; }
    }

    public class ShippingMethod
    {
        [JsonPropertyName("isShippingMethod")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("isLetter")]
        public bool IsLetter { get; set; }

        [JsonPropertyName("isInsured")]
        public bool IsInsured { get; set; }
    }
}
