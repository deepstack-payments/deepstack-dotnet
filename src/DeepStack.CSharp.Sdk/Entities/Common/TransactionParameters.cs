using System.Collections.Generic;
using DeepStack.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DeepStack.Entities.Common
{
    public class TransactionParameters
    {
        public TransactionParameters()
        {
            Capture = true;
            AVS = true;
        }
        /// <summary>
        /// A non-negative integer representing the smallest unit of the specified currency (example; 499 = $4.99 in USD)
        /// </summary>
        [JsonProperty("amount", Required = Required.Always)]
        public int Amount { get; set; }
        
        /// <summary>
        /// A list of fees included in the Amount.
        /// </summary>
        [JsonProperty("fees", NullValueHandling = NullValueHandling.Ignore)]
        public List<Fee> Fees { get; set; }
        
        /// <summary>
        /// Custom Merchant Dynamic Descriptor
        /// </summary>
        [JsonProperty("descriptor", NullValueHandling = NullValueHandling.Ignore)]
        public string Descriptor { get; set; }

        /// <summary>
        /// When set to true (default), the charge will be immediately captured against the payment method specified.
        /// When set to false, performs an authorization only and must be captured explicitly later.
        /// </summary>
        [JsonProperty("capture", Required = Required.Always)]
        public bool Capture { get; set; }

        /// <summary>
        /// Specifies cof types of the transaction: UNSCHEDULED_CARDHOLDER | UNSCHEDULED_MERCHANT | RECURRING | INSTALLMENT
        /// </summary>
        [JsonProperty("cof_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CofType? CofType { get; set; }

        /// <summary>
        /// The ISO currency code for this charge request. (eg: USD)
        /// </summary>
        [JsonProperty("currency_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCode CurrencyCode { get; set; }

        /// <summary>
        /// The two character country code for this charge (eg: US)
        /// </summary>
        [JsonProperty("country_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ISO3166CountryCode CountryCode { get; set; }
        
        /// <summary>
        /// The AVS setting should almost always be true (default)
        /// </summary>
        [JsonProperty("avs")]
        public bool AVS { get; set; }
 
        /// <summary>
        /// The browser header. Used for enhanced fraud checks.
        /// </summary>
        [JsonProperty("save_payment_instrument")]
        public bool SavePaymentInstrument { get; set; }
        
        [JsonProperty("kount_session_id", NullValueHandling = NullValueHandling.Ignore)]
        public string KountSessionId { get; set; }


    }
}