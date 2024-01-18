using System;
using DeepStack.Entities.Interface;
using DeepStack.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DeepStack.Entities.Common
{
    public abstract class PaymentInstrument : IPaymentInstrument
    {

        [JsonProperty("id", Order = -2)]
        public string Id { get; set; }

        [JsonProperty("type", Order = -1, Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentSourceType Type { get; set; }

        /*
         * The ClientId and AccountNumberHash comprise an index
         * in the DynamoDB table
         *
         */

        /// <summary>
        /// The company Id for the payment method.
        /// The company application never needs to submit this.
        /// It is resolved based on their API credentials, or
        /// the JWT when submitted via JS SDK
        /// </summary>
        [JsonProperty("client_id", Order = -1)]
        public abstract string ClientId { get; set; }

        /// <summary>
        /// The unique identifier for the customer
        /// </summary>
        [JsonProperty("customer_id", Order = 2)]
        public abstract string CustomerId { get; set; }

        /// <summary>
        /// The unique identifier for the customer
        /// </summary>
        [JsonProperty("client_customer_id", Order = 3)]
        public abstract string ClientCustomerId { get; set; }

        /// <summary>
        /// The billing contact info for the PaymentInstrument
        /// </summary>
        public abstract BillingContact BillingContact { get; set; }

        public abstract string Data { get; set; }

        public abstract DateTime Created { get; set; }

        public abstract DateTime Updated { get; set; }

        public abstract string OriginalNetworkTransactionIdentifier { get; set; }
        
    }
}
