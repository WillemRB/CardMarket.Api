using System;
using Microsoft.Extensions.Configuration;

namespace CardMarket.Api.Tests
{
    public static class ApiClientSetup
    {
        private const string APP_TOKEN = "MKM_SANDBOX_APP_TOKEN";
        private const string APP_SECRET = "MKM_SANDBOX_APP_SECRET";
        private const string ACCESS_TOKEN = "MKM_SANDBOX_ACCESS_TOKEN";
        private const string ACCESS_TOKEN_SECRET = "MKM_SANDBOX_ACCESS_TOKEN_SECRET";

        public static CardMarketApiClient CreateApiClient()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

            return new CardMarketApiClient(
                config[APP_TOKEN],
                config[APP_SECRET],
                config[ACCESS_TOKEN],
                config[ACCESS_TOKEN_SECRET],
                options: new CardMarketApiClientOptions
                {
                    ApiEnvironment = ApiEnvironment.Sandbox,
                }
            );
        }
    }
}
