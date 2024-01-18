using DeepStack.Requests.Base;
using Newtonsoft.Json;

namespace DeepStack.Requests
{
    public class RefundRequest : Request
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("charge")]
        public string Charge { get; set; }
    }
}