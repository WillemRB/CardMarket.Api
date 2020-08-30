using System;

namespace CardMarket.Api
{
    public struct Environment
    {
        public string Name { get; private set; }

        public string Uri { get; private set; }

        public static Environment CardMarket 
        {
            get
            {
                return new Environment { Uri = "https://api.cardmarket.com", Name = "CardMarket" };
            }
        }

        public static Environment Sandbox
        {
            get
            {
                return new Environment { Uri = "https://sandbox.cardmarket.com", Name = "Sandbox" };
            }
        }
    }

    public class CardMarketApiClientOptions
    {
        /// <summary>
        /// <para>Configure the environment that is used to send requests to.</para>
        /// <para>Defaults to the CardMarket environment.</para>
        /// </summary>
        public Environment Environment { get; private set; } = Environment.CardMarket;
    }
}
