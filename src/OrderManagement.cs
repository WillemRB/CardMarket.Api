using System.Collections.Generic;
using System.Text.Json;
using CardMarket.Api.Entities;
using CardMarket.Api.Structs;

namespace CardMarket.Api
{
    public partial class CardMarketApiClient
    {
        public IList<Order> FilterOrders(Actor actor, OrderStatus status, int start = 1)
        {
            var response = ExecuteRequest($"{Options.ApiEnvironment.Uri}/ws/v2.0/output.json/orders/{actor}/{status}/{start}", "GET");

            var options = new JsonSerializerOptions { WriteIndented = true };

            return JsonSerializer.Deserialize<OrderResponse>(response, options).Orders;
        }
    }
}
