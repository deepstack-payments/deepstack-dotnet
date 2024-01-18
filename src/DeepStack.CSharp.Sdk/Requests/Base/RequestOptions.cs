namespace DeepStack.Requests.Base
{
    /// <summary>
    /// Class used to perform per-request configuration of Globally Paid SDK settings
    /// </summary>
    public class RequestOptions
    {
        /// <summary>
        /// Reconfigure the Globally Paid Publishable API key
        /// </summary>
        /// <param name="publishableApiKey">The Globally Paid Publishable API key to be used for this particular service call</param>
        public RequestOptions(string publishableApiKey)
        {
            PublishableApiKey = publishableApiKey;
        }

        /// <summary>
        /// Reconfigure the Globally Paid Shared Secret and APP ID
        /// </summary>
        /// <param name="sharedSecret">The Globally Paid Shared Secret to be used for this particular service call</param>
        /// <param name="appId">The Globally Paid APP ID to be used for this particular service call</param>
        public RequestOptions(string sharedSecret, string appId)
        {
            SharedSecret = sharedSecret;
            AppId = appId;
        }

        /// <summary>
        /// Reconfigure the Globally Paid Publishable API Key, Shared Secret and APP ID
        /// </summary>
        /// <param name="publishableApiKey">The Globally Paid Publishable API key to be used for this particular service call</param>
        /// <param name="sharedSecret">The Globally Paid Shared Secret to be used for this particular service call</param>
        /// <param name="appId">The Globally Paid APP ID to be used for this particular service call</param>
        public RequestOptions(string publishableApiKey, string sharedSecret, string appId)
        {
            PublishableApiKey = publishableApiKey;
            SharedSecret = sharedSecret;
            AppId = appId;
        }

        /// <summary>
        /// Reconfigure the Globally Paid API Key, Shared Secret, APP ID and the usage of the Sandbox API
        /// </summary>
        /// <param name="publishableApiKey">The Globally Paid Publishable API key to be used for this particular service call</param>
        /// <param name="sharedSecret">The Globally Paid Shared Secret to be used for this particular service call</param>
        /// <param name="appId">The Globally Paid APP ID to be used for this particular service call</param>
        /// <param name="useSandbox">True if your service calls should go through the Globally Paid Sandbox API, 
        /// False if your service calls should go through the Globally Paid API (for this particular service call)</param>
        public RequestOptions(string publishableApiKey, string sharedSecret, string appId, bool useSandbox)
        {
            PublishableApiKey = publishableApiKey;
            SharedSecret = sharedSecret;
            AppId = appId;
            UseSandbox = useSandbox;
        }

        /// <summary>
        /// Reconfigure the Globally Paid Publishable API Key, Shared Secret, APP ID and the Globally Paid API request timeout (in seconds)
        /// </summary>
        /// <param name="publishableApiKey">The Globally Paid Publishable API key to be used for this particular service call</param>
        /// <param name="sharedSecret">The Globally Paid Shared Secret to be used for this particular service call</param>
        /// <param name="appId">The Globally Paid APP ID to be used for this particular service call</param>
        /// <param name="requestTimeoutSeconds">The request timeout (in seconds) of this particular service call. Default is 30 seconds.</param>
        public RequestOptions(string publishableApiKey, string sharedSecret, string appId, int requestTimeoutSeconds)
        {
            PublishableApiKey = publishableApiKey;
            SharedSecret = sharedSecret;
            AppId = appId;
            RequestTimeoutSeconds = requestTimeoutSeconds;
        }

        /// <summary>
        /// Reconfigure the usage of the Sandbox API
        /// </summary>
        /// <param name="useSandbox">True if your service calls should go through the Globally Paid Sandbox API, 
        /// False if your service calls should go through the Globally Paid API (for this particular service call)</param>
        public RequestOptions(bool useSandbox)
        {
            UseSandbox = useSandbox;
        }

        /// <summary>
        /// Reconfigure the Globally Paid API request timeout (in seconds)
        /// </summary>
        /// <param name="requestTimeoutSeconds">The request timeout (in seconds) of this particular service call. Default is 30 seconds.</param>
        public RequestOptions(int requestTimeoutSeconds)
        {
            RequestTimeoutSeconds = requestTimeoutSeconds;
        }

        /// <summary>
        /// Reconfigure the usage of the Sandbox API and the Globally Paid API request timeout (in seconds)
        /// </summary>
        /// <param name="useSandbox">True if your service calls should go through the Globally Paid Sandbox API, 
        /// False if your service calls should go through the Globally Paid API (for this particular service call)</param>
        /// <param name="requestTimeoutSeconds">The request timeout (in seconds) of this particular service call. Default is 30 seconds.</param>
        public RequestOptions(bool useSandbox, int requestTimeoutSeconds)
        {
            UseSandbox = useSandbox;
            RequestTimeoutSeconds = requestTimeoutSeconds;
        }

        /// <summary>
        /// Reconfigure all the Globally Paid SDK settings for this particular service call
        /// </summary>
        /// <param name="publishableApiKey">The Globally Paid Publishable API key to be used for this particular service call</param>
        /// <param name="sharedSecret">The Globally Paid Shared Secret to be used for this particular service call</param>
        /// <param name="appId">The Globally Paid APP ID to be used for this particular service call</param>
        /// <param name="useSandbox">True if your service calls should go through the Globally Paid Sandbox API, 
        /// False if your service calls should go through the Globally Paid API (for this particular service call)</param>
        /// <param name="requestTimeoutSeconds">The request timeout (in seconds) of this particular service call. Default is 30 seconds.</param>
        public RequestOptions(string publishableApiKey, string sharedSecret, string appId, bool useSandbox, int requestTimeoutSeconds)
        {
            PublishableApiKey = publishableApiKey;
            SharedSecret = sharedSecret;
            AppId = appId;
            UseSandbox = useSandbox;
            RequestTimeoutSeconds = requestTimeoutSeconds;
        }

        /// <summary>
        /// The Globally Paid Publishable API Key to be reconfigured for this service call
        /// </summary>
        public string PublishableApiKey { get; set; }

        /// <summary>
        /// The Globally Paid Shared Secret to be reconfigured for this service call
        /// </summary>
        public string SharedSecret { get; set; }

        /// <summary>
        /// The Globally Paid APP ID to be reconfigured for this service call
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// The Globally Paid usage of sandbox API to be reconfigured for this service call
        /// True if your service calls should go through the Globally Paid Sandbox API, 
        /// False if your service calls should go through the Globally Paid API (for this particular service call)
        /// </summary>
        public bool? UseSandbox { get; set; }

        /// <summary>
        /// The Globally Paid API request timeout (in seconds) to be reconfigured for this service call. Default is 30 seconds.
        /// </summary>
        public int? RequestTimeoutSeconds { get; set; }
    }
}