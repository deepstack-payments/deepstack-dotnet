using DeepStack.Entities.Common;
using DeepStack.Entities.Interface;
using DeepStack.Requests.Base;
using Newtonsoft.Json;

namespace DeepStack.Requests
{
    public class ChargeRequest : Request
    {
        /// <summary>
        /// The ID of the payment method to be charged
        /// </summary>
        [JsonProperty("source", Required = Required.Always)]
        public IPaymentSource Source { get; set; }

        [JsonProperty("transaction")]
        public TransactionParameters Params { get; set; }
        
        [JsonProperty("meta")]
        public TransactionMeta Meta { get; set; }
    }
}