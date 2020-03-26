using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RingIntegration
{
    public abstract class RingHttpClient
    {
        public abstract string AccessToken { get; }
        protected async Task<HttpResponseMessage> MakePostRequest(string url, string request, IEnumerable<Tuple<string,string>> headers = null)
        {
            var httpClient = GetHttpClient(headers);

            return await httpClient.PostAsync(url, new StringContent(request, Encoding.UTF8, "application/json"));
        }

        protected async Task<HttpResponseMessage> MakeGetRequest(string url, IEnumerable<Tuple<string, string>> headers = null)
        {
            var httpClient = GetHttpClient(headers);
            var result =  await httpClient.GetAsync(url);

            return result;
        }

        private HttpClient GetHttpClient(IEnumerable<Tuple<string,string>> headers)
        {
            var httpHandler = new HttpClientHandler
            {
                AllowAutoRedirect = true,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            var httpClient = new HttpClient(httpHandler);

            if (headers != null)
            {
                foreach (var (item1, item2) in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(item1, item2);
                }
            }

            if (!string.IsNullOrEmpty(AccessToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            }

            return httpClient;
        }
    }
}