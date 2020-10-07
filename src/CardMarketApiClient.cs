﻿using System.Collections.Generic;
using System.IO;
using System.Net;
using CardMarket.Api.Entities;
using Jil;

namespace CardMarket.Api
{
    public class CardMarketApiClient
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
            this.AppToken = appToken;
            this.AppSecret = appSecret;
            this.AccessToken = accessToken;
            this.AccessSecret = accessSecret;
            Options = options;
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

        public List<Article> GetStock(int start = 1, int maxResults = 100)
        {
            var result = ExecuteRequest($"{Options.ApiEnvironment.Uri}/ws/v2.0/output.json/stock/{start}?maxResults={maxResults}", "GET");

            return JSON.Deserialize<StockResponse>(result).Articles;
        }

        public List<Game> GetGames()
        {
            var result = ExecuteRequest($"{Options.ApiEnvironment.Uri}/ws/v2.0/output.json/games", "GET");

            return JSON.Deserialize<GameResponse>(result).Games;
        }
    }
}
