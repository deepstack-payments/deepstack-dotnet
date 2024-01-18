using DeepStack.Entities.Common;
using DeepStack.Entities.Interface;
using DeepStack.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DeepStack.Requests
{
    public class PaymentSource : IPaymentSource
    {
        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentSourceType Type { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("billing_contact", NullValueHandling = NullValueHandling.Ignore)]
        public BillingContact BillingContact { get; set; }
        
    }
}