using System;
namespace CardMarket.Api.Tests
{
    public class ApiClientSetup
    {
        private const string APP_TOKEN = "MKM_SANDBOX_APP_TOKEN";
        private const string APP_SECRET = "MKM_SANDBOX_APP_SECRET";
        private const string ACCESS_TOKEN = "MKM_SANDBOX_ACCESS_TOKEN";
        private const string ACCESS_TOKEN_SECRET = "MKM_SANDBOX_ACCESS_TOKEN_SECRET";

        public CardMarketApiClient CreateApiClient()
        {
            return new CardMarketApiClient(
                Environment.GetEnvironmentVariable(APP_TOKEN),
                Environment.GetEnvironmentVariable(APP_SECRET),
                Environment.GetEnvironmentVariable(ACCESS_TOKEN),
                Environment.GetEnvironmentVariable(ACCESS_TOKEN_SECRET),
                options: new CardMarketApiClientOptions
                {
                    ApiEnvironment = ApiEnvironment.Sandbox,
                }
            );
        }
    }
}
