using DeepStack.Entities.Base;
using Newtonsoft.Json;

namespace DeepStack.Entities.Common
{
    public class Fee : Entity
    {
        [JsonProperty("fee_type")]
        public string FeeType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("amount")] public int Amount { get; set; } = 0;
    }
}
