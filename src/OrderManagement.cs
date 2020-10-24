using System.Collections.Generic;
using CardMarket.Api.Entities;
using CardMarket.Api.Structs;
using Jil;

namespace CardMarket.Api
{
    public partial class CardMarketApiClient
    {
        public IList<Order> FilterOrders(Actor actor, OrderStatus status, int start = 1)
        {
            var response = ExecuteRequest($"{Options.ApiEnvironment.Uri}/ws/v2.0/output.json/orders/{actor}/{status}/{start}", "GET");

            return JSON.Deserialize<OrderResponse>(response, Jil.Options.ISO8601PrettyPrint).Orders;
        }
    }
}
