using System.Configuration;

namespace DeepStack.Core
{
    /// <summary>
    /// Global configuration class for Globally Paid SDK settings
    /// </summary>
    public static class DeepStackConfiguration
    {
        private const string PUBLISHABLE_API_KEY = "DeepStackPublishableApiKey";
        private const string SHARED_SECRET = "DeepStackSharedSecret";
        private const string APP_ID = "DeepStackAppId";
        private const string USE_SANDBOX = "DeepStackUseSandbox";
        private const string REQUEST_TIMEOUT_SECONDS = "DeepStackRequestTimeoutSeconds";

        private static string publishableApiKey;
        private static string sharedSecret;
        private static string appId;
        private static bool useSandbox;
        private static int requestTimeoutSeconds;

        private static HttpServiceClient client;

        /// <summary>
        /// Static method that can be used for globally configuring DeepStack SDK settings
        /// </summary>
        /// <param name="publishableApiKey">DeepStack Publishable API Key</param>
        /// <param name="sharedSecret">DeepStack Shared Secret</param>
        /// <param name="appId">DeepStack APP ID</param>
        /// <param name="useSandbox">True if your service calls should go through the DeepStack Sandbox API, 
        /// False if your service calls should go through the DeepStack API</param>
        /// <param name="requestTimeoutSeconds">The request timeout (in seconds) of all DeepStack Sandbox API service calls. Default is 30 seconds.</param>
        public static void Setup(string publishableApiKey, string sharedSecret, string appId, bool? useSandbox = null, int? requestTimeoutSeconds = null)
        {
            PublishableApiKey = publishableApiKey;
            SharedSecret = sharedSecret;
            AppId = appId;
            
            if (useSandbox.HasValue)
            {
                UseSandbox = useSandbox.Value;
            }

            if (requestTimeoutSeconds.HasValue)
            {
                RequestTimeoutSeconds = requestTimeoutSeconds.Value;
            }
        }

        internal static HttpServiceClient Client
        {
            get
            {
                if (client == null)
                {
                    var baseUrl = UseSandbox ? DeepStackConstants.DefaultSandboxBaseUrl : DeepStackConstants.DefaultBaseUrl;
                    client = new HttpServiceClient(new HttpServiceClientConfiguration(baseUrl, DeepStackConstants.BearerAuthenticationScheme, PublishableApiKey, RequestTimeoutSeconds));
                }

                return client;
            }

            set => client = value;
        }

        /// <summary>
        /// Gets or sets the Globally Paid Publishable API key
        /// </summary>
        /// <remarks>
        /// Publishable API key can also be set using the <see cref="PUBLISHALE_API_KEY"/> key in
        /// <see cref="ConfigurationManager.AppSettings"/>.
        /// </remarks>
        public static string PublishableApiKey
        {
            get
            {
                if (string.IsNullOrEmpty(publishableApiKey) &&
                    !string.IsNullOrEmpty(ConfigurationManager.AppSettings[PUBLISHABLE_API_KEY]))
                {
                    publishableApiKey = ConfigurationManager.AppSettings[PUBLISHABLE_API_KEY];
                }

                return publishableApiKey;
            }

            set
            {
                if (value != publishableApiKey)
                {
                    Client = null;
                }

                publishableApiKey = value;
            }
        }

        /// <summary>
        /// Gets or sets the Globally Paid Shared Secret
        /// </summary>
        /// <remarks>
        /// Shared Secret can also be set using the <see cref="SHARED_SECRET"/> key in
        /// <see cref="ConfigurationManager.AppSettings"/>.
        /// </remarks>
        public static string SharedSecret
        {
            get
            {
                if (string.IsNullOrEmpty(sharedSecret) &&
                    !string.IsNullOrEmpty(ConfigurationManager.AppSettings[SHARED_SECRET]))
                {
                    sharedSecret = ConfigurationManager.AppSettings[SHARED_SECRET];
                }

                return sharedSecret;
            }

            set
            {
                if (value != sharedSecret)
                {
                    Client = null;
                }

                sharedSecret = value;
            }
        }

        /// <summary>
        /// Gets or sets the Globally Paid APP ID
        /// </summary>
        /// <remarks>
        /// App Id can also be set using the <see cref="APP_ID"/> key in
        /// <see cref="ConfigurationManager.AppSettings"/>.
        /// </remarks>
        public static string AppId
        {
            get
            {
                if (string.IsNullOrEmpty(appId) &&
                    !string.IsNullOrEmpty(ConfigurationManager.AppSettings[APP_ID]))
                {
                    appId = ConfigurationManager.AppSettings[APP_ID];
                }

                return appId;
            }

            set
            {
                if (value != appId)
                {
                    Client = null;
                }

                appId = value;
            }
        }

        /// <summary>
        /// Gets or sets whether your service calls should go through the GLobally Paid Sandbox API   
        /// True if your service calls should go through the Globally Paid Sandbox API, 
        /// False if your service calls should go through the Globally Paid API
        /// </summary>
        /// <remarks>
        /// The usage of Sandbox API can also be set using the <see cref="USE_SANDBOX"/> key in
        /// <see cref="ConfigurationManager.AppSettings"/>.
        /// </remarks>
        public static bool UseSandbox
        {
            get
            {
                if (!useSandbox &&
                    !string.IsNullOrEmpty(ConfigurationManager.AppSettings[USE_SANDBOX]))
                {
                    useSandbox = bool.Parse(ConfigurationManager.AppSettings[USE_SANDBOX]);
                }

                return useSandbox;
            }

            set
            {
                if (value != useSandbox)
                {
                    Client = null;
                }

                useSandbox = value;
            }
        }

        /// <summary>
        /// Gets or sets the request timeout (in seconds) of all Globally Paid Sandbox API service calls. Default is 30 seconds.
        /// </summary>
        /// <remarks>
        /// Request timeout (in seconds) can also be set using the <see cref="REQUEST_TIMEOUT_SECONDS"/> key in
        /// <see cref="ConfigurationManager.AppSettings"/>.
        /// </remarks>
        public static int RequestTimeoutSeconds
        {
            get
            {
                if (requestTimeoutSeconds == default &&
                     !string.IsNullOrEmpty(ConfigurationManager.AppSettings[REQUEST_TIMEOUT_SECONDS]))
                {
                    requestTimeoutSeconds = int.Parse(ConfigurationManager.AppSettings[REQUEST_TIMEOUT_SECONDS]);
                }

                return requestTimeoutSeconds;
            }

            set
            {
                if (value != requestTimeoutSeconds)
                {
                    Client = null;
                }

                requestTimeoutSeconds = value;
            }
        }
    }
}
