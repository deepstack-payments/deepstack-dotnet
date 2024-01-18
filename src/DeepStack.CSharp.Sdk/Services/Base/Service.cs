using System;
using System.Net.Http.Headers;
using DeepStack.Core;
using DeepStack.Extensions;
using DeepStack.Requests.Base;

namespace DeepStack.Services.Base
{
    /// <summary>
    /// Base class for all Globally Paid services
    /// </summary>
    public abstract class Service
    {
        public Service()
        {
        }

        public Service(HttpServiceClient client)
        {
            Client = client;
        }

        private HttpServiceClient client;

        protected HttpServiceClient Client
        {
            get => client ?? DeepStackConfiguration.Client;
            set => client = value;
        }
        protected const string HMAC = "hmac";

        protected abstract string BasePath { get; }

        protected void TryReconfigureClient(object request, RequestOptions requestOptions = null, string requestMethod = "POST")
        {
            // By default this will send the publishable key in requests... can manually remove this
            // But no harm in sending it here
            TryReconfigureClient(requestOptions);

            Client.Headers.Remove(HMAC);
            
            var sharedSecret = requestOptions?.SharedSecret ?? DeepStackConfiguration.SharedSecret;
            var appId = requestOptions?.AppId ?? DeepStackConfiguration.AppId;
            
            var authenticationString = $"{appId}:{sharedSecret}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));


            //Don't want to send this anymore if HMAC is re-enabled
            // Client.AuthorizationHeader = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
            
            // Send hmac in 'hmac' header
            // Assume request is a post unless specified.. if it's not a post, default will fail anyways
            Client.Headers.Add(HMAC, request.CreateHMAC(sharedSecret, appId, requestMethod));
        }

        protected void TryReconfigureClient(RequestOptions requestOptions = null)
        {
            if (requestOptions?.RequestTimeoutSeconds != default || requestOptions?.UseSandbox != default)
            {
                var useSandbox = requestOptions?.UseSandbox != default 
                    ? requestOptions.UseSandbox.GetValueOrDefault()
                    : DeepStackConfiguration.UseSandbox;

                var baseUrl = useSandbox
                    ? DeepStackConstants.DefaultSandboxBaseUrl
                    : DeepStackConstants.DefaultBaseUrl;

                var timeout = requestOptions?.RequestTimeoutSeconds != default
                    ? requestOptions?.RequestTimeoutSeconds
                    : DeepStackConfiguration.RequestTimeoutSeconds;

                Client = new HttpServiceClient(new HttpServiceClientConfiguration(baseUrl, timeout));
            }

            Client.AuthorizationHeader = new AuthenticationHeaderValue(DeepStackConstants.BearerAuthenticationScheme,
                requestOptions?.PublishableApiKey ?? DeepStackConfiguration.PublishableApiKey);
        }
    }
}
