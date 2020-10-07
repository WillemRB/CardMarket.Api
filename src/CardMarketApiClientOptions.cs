namespace CardMarket.Api
{
    public struct ApiEnvironment
    {
        public string Name { get; private set; }

        public string Uri { get; private set; }

        public static ApiEnvironment CardMarket 
        {
            get
            {
                return new ApiEnvironment { Uri = "https://api.cardmarket.com", Name = "CardMarket" };
            }
        }

        public static ApiEnvironment Sandbox
        {
            get
            {
                return new ApiEnvironment { Uri = "https://sandbox.cardmarket.com", Name = "Sandbox" };
            }
        }
    }

    public class CardMarketApiClientOptions
    {
        /// <summary>
        /// <para>Configure the API environment that is used to send requests to.</para>
        /// <para>Defaults to the CardMarket environment.</para>
        /// </summary>
        /// <remarks>
        /// <para>The sandbox environment is only used for testing purposes.</para>
        /// </remarks>
        public ApiEnvironment ApiEnvironment { get; set; } = ApiEnvironment.CardMarket;
    }
}
