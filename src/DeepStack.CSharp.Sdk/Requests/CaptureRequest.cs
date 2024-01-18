using DeepStack.Requests.Base;
using Newtonsoft.Json;

namespace DeepStack.Requests
{
    public class CaptureRequest : Request
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("charge")]
        public string Charge { get; set; }
    }
}