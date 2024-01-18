using DeepStack.Entities.Common;
using DeepStack.Enums;
using DeepStack.Requests.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DeepStack.Requests
{
    public class UpdatePaymentInstrumentRequest : Request
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentType Type { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("client_customer_id")]
        public string ClientCustomerId { get; set; }

        [JsonProperty("billing_contact")]
        public Contact BillingContact { get; set; }
    }
}
