using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardMarket.Api.UnitTests
{
    [TestClass]
    public class CardMarketApiClientTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AppTokenIsNull_ThrowsArgumentException()
        {
            new CardMarketApiClient(null, "2", "3", "4");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AppSecretIsNull_ThrowsArgumentException()
        {
            new CardMarketApiClient("1", null, "3", "4");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AccesTokenIsNull_ThrowsArgumentException()
        {
            new CardMarketApiClient("1", "2", null, "4");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AccessTokenSecretIsNull_ThrowsArgumentException()
        {
            new CardMarketApiClient("1", "2", "3", null);
        }
    }
}
