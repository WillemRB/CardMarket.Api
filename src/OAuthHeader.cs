using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CardMarket.Api
{
    internal class OAuthHeader
    {
        protected string AccessSecret { get; private set; }
        protected string AccessToken { get; private set; }
        protected string AppSecret { get; private set; }
        protected string AppToken { get; private set; }

        protected IDictionary<string, string> headerParams;

        public OAuthHeader(string appToken, string appSecret, string accessToken, string accessSecret)
        {
            AppToken = appToken;
            AppSecret = appSecret;
            AccessToken = accessToken;
            AccessSecret = accessSecret;

            var nonce = Guid.NewGuid().ToString("N").Substring(0, 15);
            var timestamp = (uint)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

            headerParams = new Dictionary<string, string>
            {
                { "oauth_consumer_key", appToken },
                { "oauth_token", accessToken },
                { "oauth_nonce", nonce },
                { "oauth_timestamp", timestamp.ToString() },
                { "oauth_signature_method", "HMAC-SHA1" },
                { "oauth_version", "1.0" }
            };
        }

        public static SortedDictionary<string, string> ParseQueryString(string query)
        {
            var queryParameters = new SortedDictionary<string, string>();
            var querySegments = query.Split('&');
            foreach (var segment in querySegments)
            {
                var parts = segment.Split('=');
                if (parts.Length > 0)
                {
                    var key = parts[0].Trim('?', ' ');
                    var val = parts[1].Trim();

                    queryParameters.Add(key, val);
                }
            }

            return queryParameters;
        }

        public string GetAuthorizationHeader(string method, string url)
        {
            var uri = new Uri(url);
            var baseUri = uri.GetLeftPart(UriPartial.Path);

            headerParams.Add("realm", baseUri);

            // Start composing the base string from the method and request URI
            var baseString = $"{method.ToUpper()}&{Uri.EscapeDataString(baseUri)}&";

            var index = url.IndexOf("?");

            if (index > 0)
            {
                var urlParams = url.Substring(index).Remove(0, 1);

                var args = ParseQueryString(urlParams);

                foreach (var k in args)
                {
                    headerParams.Add(k.Key, k.Value);
                }
            }

            // Gather, encode, and sort the base string parameters
            var encodedParams = new SortedDictionary<string, string>();
            foreach (var parameter in headerParams)
            {
                if (parameter.Key.Equals("realm"))
                    continue;

                encodedParams.Add(Uri.EscapeDataString(parameter.Key), Uri.EscapeDataString(parameter.Value));
            }

            // Expand the base string by the encoded parameter=value pairs
            var paramStrings = new List<string>();
            foreach (var parameter in encodedParams)
            {
                paramStrings.Add($"{parameter.Key}={parameter.Value}");
            }
            var paramString = Uri.EscapeDataString(string.Join<string>("&", paramStrings));
            baseString += paramString;

            // Create the OAuth signature
            var signatureKey = $"{Uri.EscapeDataString(AppSecret)}&{Uri.EscapeDataString(AccessSecret)}";

            // Using HMACSHA1.Create() throws a PlatformNotSupportedException
            // Calling CryptoConfig is a workaround
            var hasher = (HMACSHA1)CryptoConfig.CreateFromName("HMACSHA1");

            hasher.Key = Encoding.UTF8.GetBytes(signatureKey);
            var rawSignature = hasher.ComputeHash(Encoding.UTF8.GetBytes(baseString));
            var oAuthSignature = Convert.ToBase64String(rawSignature);

            // Include the OAuth signature parameter in the header parameters array
            headerParams.Add("oauth_signature", oAuthSignature);

            // Construct the header string
            var headerParamStrings = new List<string>();
            foreach (var parameter in headerParams)
            {
                headerParamStrings.Add($"{parameter.Key}=\"{parameter.Value}\"");
            }
            var authHeader = "OAuth " + string.Join<string>(", ", headerParamStrings);

            return authHeader;
        }
    }
}
