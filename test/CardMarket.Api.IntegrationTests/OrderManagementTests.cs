using CardMarket.Api.Structs;
using CardMarket.Api.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardMarket.Api.IntegrationTests
{
    [TestClass, TestCategory("Integration")]
    public class OrderManagementTests
    {
        private CardMarketApiClient _client;

        [TestInitialize]
        public void Initialize()
        {
            _client = ApiClientSetup.CreateApiClient();
        }

        [TestMethod]
        public void FilterOrders()
        {
            // Act
            var result = _client.FilterOrders(Actor.Buyer, OrderStatus.Received);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
