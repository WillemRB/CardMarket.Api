using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using CardMarket.Api.Entities;
using System.Text.Json;

namespace CardMarket.Api
{
    public partial class CardMarketApiClient
    {
        protected string AccessSecret { get; private set; }
        protected string AccessToken { get; private set; }
        protected string AppSecret { get; private set; }
        protected string AppToken { get; private set; }

        public CardMarketApiClientOptions Options { get; private set; }

        public int RequestCount { get; private set; } = -1;

        public int RequestLimit { get; private set; } = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appToken">Your appToken</param>
        /// <param name="appSecret">Your appSecret</param>
        /// <param name="accessToken">Your accessToken</param>
        /// <param name="accessSecret">Your accessSecret</param>
        public CardMarketApiClient(string appToken, string appSecret, string accessToken, string accessSecret)
            : this(appToken, appSecret, accessToken, accessSecret, new CardMarketApiClientOptions())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appToken">Your appToken</param>
        /// <param name="appSecret">Your appSecret</param>
        /// <param name="accessToken">Your accessToken</param>
        /// <param name="accessSecret">Your accessSecret</param>
        /// <param name="options"></param>
        public CardMarketApiClient(string appToken, string appSecret, string accessToken, string accessSecret, CardMarketApiClientOptions options)
        {
            if (string.IsNullOrEmpty(appToken))
                throw new ArgumentException(nameof(appToken));
            if (string.IsNullOrEmpty(appSecret))
                throw new ArgumentException(nameof(appSecret));
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentException(nameof(accessToken));
            if (string.IsNullOrEmpty(accessSecret))
                throw new ArgumentException(nameof(accessSecret));

            this.AppToken = appToken;
            this.AppSecret = appSecret;
            this.AccessToken = accessToken;
            this.AccessSecret = accessSecret;
            Options = options ?? new CardMarketApiClientOptions();
        }

        private string ExecuteRequest(string url, string method, string body = null)
        {
            var request = WebRequest.CreateHttp(url);
            request.Method = method;

            var header = new OAuthHeader(AppToken, AppSecret, AccessToken, AccessSecret);
            request.Headers.Add(HttpRequestHeader.Authorization, header.GetAuthorizationHeader(method, url));

            if (body != null)
            {
                request.ServicePoint.Expect100Continue = false;
                request.ContentLength = body.Length;
                request.ContentType = "text/xml";

                var writer = new StreamWriter(request.GetRequestStream());

                writer.Write(body);
                writer.Close();
            }

            var response = request.GetResponse() as HttpWebResponse;

            var json = string.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                json = reader.ReadToEnd();
            }

            RequestCount = int.Parse(response.Headers.Get("X-Request-Limit-Count"));
            RequestLimit = int.Parse(response.Headers.Get("X-Request-Limit-Max"));

            return json;
        }

        public IList<Article> GetStock(int start = 1, int maxResults = 100)
        {
            var result = ExecuteRequest($"{Options.ApiEnvironment.Uri}/ws/v2.0/output.json/stock/{start}?maxResults={maxResults}", "GET");

            return JsonSerializer.Deserialize<StockResponse>(result).Articles;
        }

        public IList<Game> GetGames()
        {
            var result = ExecuteRequest($"{Options.ApiEnvironment.Uri}/ws/v2.0/output.json/games", "GET");

            return JsonSerializer.Deserialize<GameResponse>(result).Games;
        }
    }
}
