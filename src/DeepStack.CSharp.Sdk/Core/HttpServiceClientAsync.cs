using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DeepStack.Core
{
    public partial class HttpServiceClient
    {
        public async Task<TEntity> GetAsync<TEntity>(string resourceUri, bool checkResponseCode = false, CancellationToken cancellationToken = default) where TEntity : class
        {
            var responseMessage = await GetResponseMessageAsync(x => x.GetAsync(resourceUri, cancellationToken));
            return await ReadResponseAsync<TEntity>(responseMessage, checkResponseCode);
        }

        public async Task<TEntity> PostAsync<TData, TEntity>(string resourceUri, TData data, bool checkResponseCode = false, CancellationToken cancellationToken = default) where TEntity : class
        {
            var responseMessage = await GetResponseMessageAsync(GetPostAction(resourceUri, data, cancellationToken));
            return await ReadResponseAsync<TEntity>(responseMessage, checkResponseCode);
        }

        public async Task<TEntity> PutAsync<TData, TEntity>(string resourceUri, TData data, bool checkResponseCode = false, CancellationToken cancellationToken = default) where TEntity : class
        {
            var responseMessage = await GetResponseMessageAsync(GetPutAction(resourceUri, data, cancellationToken));
            return await ReadResponseAsync<TEntity>(responseMessage, checkResponseCode);
        }

        public async Task<TEntity> PatchAsync<TData, TEntity>(string resourceUri, TData data, bool checkResponseCode = false, CancellationToken cancellationToken = default) where TEntity : class
        {
            var responseMessage = await GetResponseMessageAsync(GetPatchAction(resourceUri, data, cancellationToken));
            return await ReadResponseAsync<TEntity>(responseMessage, checkResponseCode);
        }

        public async Task DeleteAsync(string resourceUri, CancellationToken cancellationToken = default)
        {
            await GetResponseMessageAsync(GetDeleteAction(resourceUri, cancellationToken));
        }

        private async Task<HttpResponseMessage> GetResponseMessageAsync(Func<HttpClient, Task<HttpResponseMessage>> action, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await action(HttpClient).ConfigureAwait(false);
        }

        private async Task<TEntity> ReadResponseAsync<TEntity>(HttpResponseMessage responseMessage, bool checkResponseCode = false)
            where TEntity : class
        {
            var content = await responseMessage.Content.ReadAsStringAsync();
            var globallyPaidResponse = new HttpServiceClientResponse(responseMessage.StatusCode, responseMessage.Headers, content);

            if (globallyPaidResponse.StatusCode == HttpStatusCode.OK)
            {
                if (checkResponseCode)
                {
                    CheckResponseCode(content, globallyPaidResponse);
                }

                try
                {
                    return JsonConvert.DeserializeObject<TEntity>(content);
                }
                catch (JsonException jex)
                {
                    System.Diagnostics.Debug.Write($"Invalid response object {typeof(TEntity)} from API: \"{content}\", message: \"{jex.Message}\"");
                    throw new DeepStackException(responseMessage.StatusCode, $"Invalid response object from API: \"{content}\", message: \"{jex.Message}\"", globallyPaidResponse);
                }
            }
            else
            {
                throw new DeepStackException(responseMessage.StatusCode, content, globallyPaidResponse);
            }
        }

        private void CheckResponseCode(string content, HttpServiceClientResponse globallyPaidResponse)
        {
            var response = new { response_code = string.Empty, message = string.Empty };
            try
            {
                response = JsonConvert.DeserializeAnonymousType(content,
                      new { response_code = string.Empty, message = string.Empty });
            }
            catch (JsonException jex)
            {
                throw new DeepStackException(globallyPaidResponse.StatusCode, $"Invalid response object from API: \"{content}\", message: \"{jex.Message}\"", globallyPaidResponse);
            }

            if (response != null
                && !string.IsNullOrEmpty(response.response_code)
                && !string.IsNullOrEmpty(response.message)
                && response.response_code != "00")
            {
                throw new DeepStackException(HttpStatusCode.BadRequest, response.message, globallyPaidResponse);
            }
        }
    }
}
