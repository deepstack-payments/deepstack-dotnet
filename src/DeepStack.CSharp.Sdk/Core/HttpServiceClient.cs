using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DeepStack.Core
{
    public partial class HttpServiceClient : IDisposable
    {
        public HttpServiceClientConfiguration Configuration { get; }
        protected HttpClient HttpClient { get; private set; }

        public HttpServiceClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public HttpServiceClient(HttpServiceClient serviceClient)
        {
            Configuration = serviceClient.Configuration;
            HttpClient = serviceClient.HttpClient;
        }

        public HttpServiceClient(HttpServiceClientConfiguration configuration)
        {
            Configuration = configuration;
            InitializeHttpClient();
        }

        public HttpHeaders Headers => HttpClient.DefaultRequestHeaders;
        public AuthenticationHeaderValue AuthorizationHeader
        {
            get
            {
                return HttpClient.DefaultRequestHeaders.Authorization;
            }

            set => HttpClient.DefaultRequestHeaders.Authorization = value;
        }

        public TEntity Get<TEntity>(string resourceUri, bool checkResponseCode = false) where TEntity : class
        {
            return ReadResponseAsync<TEntity>(GetResponseMessageAsync(x => x.GetAsync(resourceUri)).GetAwaiter().GetResult(), checkResponseCode)
                .GetAwaiter().GetResult();
        }

        public TEntity Post<TData, TEntity>(string resourceUri, TData data, bool checkResponseCode = false) where TEntity : class
        {
            return ReadResponseAsync<TEntity>(GetResponseMessageAsync(GetPostAction(resourceUri, data)).GetAwaiter().GetResult(), checkResponseCode)
                .GetAwaiter().GetResult();
        }

        public TEntity Put<TData, TEntity>(string resourceUri, TData data, bool checkResponseCode = false) where TEntity : class
        {
            return ReadResponseAsync<TEntity>(GetResponseMessageAsync(GetPutAction(resourceUri, data)).GetAwaiter().GetResult(), checkResponseCode)
                .GetAwaiter().GetResult();
        }

        public TEntity Patch<TData, TEntity>(string resourceUri, TData data, bool checkResponseCode = false) where TEntity : class
        {
            return ReadResponseAsync<TEntity>(GetResponseMessageAsync(GetPatchAction(resourceUri, data)).GetAwaiter().GetResult(), checkResponseCode)
                .GetAwaiter().GetResult();
        }

        public bool Delete(string resourceUri)
        {
            var httpResponseMessage = GetResponseMessageAsync(GetDeleteAction(resourceUri)).GetAwaiter().GetResult();
            return httpResponseMessage.IsSuccessStatusCode;
        }

        private void InitializeHttpClient()
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(Configuration.BaseUrl),
                Timeout = TimeSpan.FromSeconds(Configuration.TimeoutSeconds)
            };

            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Configuration.AcceptsMimeType));

            if (!string.IsNullOrEmpty(Configuration.AuthenticationScheme))
            {
                if (string.IsNullOrEmpty(Configuration.AuthenticationValue))
                {
                    throw new DeepStackException("Your Globally Paid Token API Key is not configured");
                }

                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Configuration.AuthenticationScheme, Configuration.AuthenticationValue);
            }
        }

        private Func<HttpClient, Task<HttpResponseMessage>> GetPostAction<TData>(string resourceUri, TData data, CancellationToken cancellationToken = default)
        {
            return x => x.PostAsync(resourceUri, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, DeepStackConstants.ApplicationJson), cancellationToken);
        }

        private Func<HttpClient, Task<HttpResponseMessage>> GetPutAction<TData>(string resourceUri, TData data, CancellationToken cancellationToken = default)
        {
            return x => x.PutAsync(resourceUri, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, DeepStackConstants.ApplicationJson), cancellationToken);
        }

        private Func<HttpClient, Task<HttpResponseMessage>> GetPatchAction<TData>(string resourceUri, TData data, CancellationToken cancellationToken = default)
        {
            return x => x.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), resourceUri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, DeepStackConstants.ApplicationJson)
            }, cancellationToken);
        }

        private Func<HttpClient, Task<HttpResponseMessage>> GetDeleteAction(string resourceUri,  CancellationToken cancellationToken = default)
        {
            return x => x.SendAsync(new HttpRequestMessage(HttpMethod.Delete, resourceUri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(string.Empty), Encoding.UTF8, DeepStackConstants.ApplicationJson)
            }, cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && HttpClient != null)
            {
                HttpClient.Dispose();
                HttpClient = null;
            }
        }
    }
}
