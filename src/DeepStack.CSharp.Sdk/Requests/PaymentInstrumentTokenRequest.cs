using DeepStack.Requests.Base;
using Newtonsoft.Json;

namespace DeepStack.Requests
{
    public class PaymentInstrumentTokenRequest : Request
    {
        
        [JsonProperty("source")]
        public string Token { get; set; }
        
        [JsonProperty("client_customer_id")]
        public string ClientCustomerId { get; set; }
        
    }
}

