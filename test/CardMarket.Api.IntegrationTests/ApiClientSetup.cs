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

        private static IConfigurationRoot config;

        public static CardMarketApiClient CreateApiClient()
        {
            config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

            return new CardMarketApiClient(
                GetConfigValue(APP_TOKEN),
                GetConfigValue(APP_SECRET),
                GetConfigValue(ACCESS_TOKEN),
                GetConfigValue(ACCESS_TOKEN_SECRET),
                options: new CardMarketApiClientOptions
                {
                    ApiEnvironment = ApiEnvironment.Sandbox,
                }
            );
        }

        /// <summary>
        /// Helper function that is used to support both appSettings.json (for local debugging)
        /// and environment variables to work with the Travis CI build.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string GetConfigValue(string key)
        {
            if (string.IsNullOrEmpty(config[key]))
                return Environment.GetEnvironmentVariable(key);
            return config[key];
        }
    }
}
