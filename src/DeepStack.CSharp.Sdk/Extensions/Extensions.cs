using DeepStack.Core;
using DeepStack.Services.v1;
using DeepStack.Services.v1.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace DeepStack.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Extension method to convert object of any type to JSON
        /// </summary>
        /// <param name="obj">the object to be converted to JSON</param>
        /// <returns>JSON string</returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// Extension method to convert JSON string to an object of type T
        /// </summary>
        /// <typeparam name="T">the type of the object to be deserialized from JSON string</typeparam>
        /// <param name="json">the JSON string</param>
        /// <returns>Deserialized object of type T</returns>
        public static T FromJson<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// Extension method to create an HMACSHA256 hash 
        /// </summary>
        /// <param name="obj">The object that will be used to generate the hash</param>
        /// <param name="sharedSecret">The Globally Paid Shared Secret</param>
        /// <param name="appId">The Globally Paid APP ID</param>
        /// <returns>The generated HMACSHA256 hash</returns>
        public static string CreateHMAC(this object obj, string sharedSecret, string appId, string requestMethod)
        {
            if (string.IsNullOrEmpty(sharedSecret))
            {
                throw new DeepStackException("Your DeepStack Shared Secret is not configured");
            }

            if (string.IsNullOrEmpty(appId))
            {
                throw new DeepStackException("Your DeepStack APP ID is not configured");
            }

            return HmacUtility.CreateHmacHeader(obj.ToJson(), sharedSecret, appId, requestMethod);
        }

        /// <summary>
        /// <see cref="IServiceCollection"/> extension method that can be used to configure all Globally Paid SDK settings
        /// and register all Globally Paid services
        /// </summary>
        /// <param name="services">the <see cref="IServiceCollection"/> services</param>
        /// <param name="publishableApiKey">The Globally Paid Publishable API Key</param>
        /// <param name="sharedSecret">The Globally Paid Shared Secret</param>
        /// <param name="appId">The Globally Paid APP ID</param>
        /// <param name="useSandbox">True if your service calls should go through the Globally Paid Sandbox API, 
        /// False if your service calls should go through the Globally Paid API</param>
        /// <param name="requestTimeoutSeconds"> The request timeout (in seconds) of all Globally Paid Sandbox API service calls. Default is 30 seconds. </param>
        /// <returns>An <see cref="IServiceCollection"/> services collection, with configured Globally Paid SDK settings and all Globally Paid services registered. </returns>
        public static IServiceCollection AddDeepStack(this IServiceCollection services, string publishableApiKey, string sharedSecret, string appId, bool? useSandbox = null, int? requestTimeoutSeconds = null)
        {
            DeepStackConfiguration.Setup(publishableApiKey, sharedSecret, appId, useSandbox, requestTimeoutSeconds);

            return AddDeepStackServices(services);
        }

        /// <summary>
        /// <see cref="IServiceCollection"/> extension method that can be used to register all Globally Paid services
        /// </summary>
        /// <param name="services">the <see cref="IServiceCollection"/> services</param>
        /// <returns>An <see cref="IServiceCollection"/> services collection, with all Globally Paid services registered. </returns>
        public static IServiceCollection AddDeepStackServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IChargeService, ChargeService>();
            services.AddScoped<ICaptureService, CaptureService>();
            services.AddScoped<IRefundService, RefundService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IPaymentInstrumentService, PaymentInstrumentService>();

            return services;
        }
    }
}
