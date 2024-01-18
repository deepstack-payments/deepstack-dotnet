using DeepStack.Entities;
using DeepStack.Entities.Common.JSCommon;
using Newtonsoft.Json;

namespace DeepStack.Requests
{
    public class BaseTokenResponse
    {
        
        /// <summary>
        /// Set amount in the JS before sending to us or use an amount from elsewhere...
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }
        
        [JsonProperty("token")]
        public string ID { get; set; }
    
        
    // /// <summary>
    //     /// Customer Id
    //     /// </summary>
    //     [JsonProperty("customer_id")]
    //     public string CustomerId { get; set; }
    //
    //     /// <summary>
    //     /// Client Id
    //     /// </summary>
    //     [JsonIgnore]
    //     [JsonProperty("client_id")]
    //     public string ClientId { get; set; }
    //
    //     /// <summary>
    //     /// ClientCustomer Id
    //     /// </summary>
    //     [JsonProperty("client_customer_id", NullValueHandling = NullValueHandling.Ignore)]
    //     public string ClientCustomerId { get; set; }

        /// <summary>
        /// The brand of the credit card, eg: Visa, Mastercard, Discover, Amex
        /// </summary>
        [JsonProperty("brand", NullValueHandling = NullValueHandling.Ignore)]
        public string Brand { get; set; }

        /// <summary>
        /// The BIN of the account number
        /// </summary>
        [JsonProperty("bin")]
        public string Bin { get; set; }
        
        /// <summary>
        /// The last four digits of the account number
        /// </summary>
        [JsonProperty("lastFour")]
        public string LastFour { get; set; }
        
        /// <summary>
        /// Full PAN for companies where return full pan is enabled
        /// </summary>
        [JsonProperty("pan", NullValueHandling = NullValueHandling.Ignore)]
        public string PAN { get; set; }

        /// <summary>
        /// If a card, the card expiration. Blank if BankAccount.
        /// </summary>
        [JsonProperty("expiration")]
        public string Expiration { get; set; }
        
        /// <summary>
        /// Card CVV
        /// </summary>
        [JsonProperty("cvv", NullValueHandling = NullValueHandling.Ignore)]
        public string CVV { get; set; }

        /// <summary>
        /// Provided from JS SDK for third party fraud checks.
        /// </summary>
        [JsonIgnore]
        [JsonProperty("kount_session_id")]
        public string KountSessionId { get; set; }

        /// <summary>
        /// Billing Contact
        /// </summary>
        [JsonProperty("billingContact")]
        public ClientBillingContact BillingContact { get; set; }
        
        /// <summary>
        /// Shipping address
        /// </summary>
        [JsonProperty("shippingContact", NullValueHandling = NullValueHandling.Ignore)]
        public ClientAddress ShippingContact { get; set; }

        // /// <summary>
        // /// Created
        // /// </summary>
        // [JsonProperty("created")]
        // public DateTime Created { get; set; }
        //
        // /// <summary>
        // /// Updated
        // /// </summary>
        // [JsonProperty("updated")]
        // public DateTime Updated { get; set; }

        // /// <summary>
        // /// Data
        // /// </summary>
        // [JsonIgnore]
        // [JsonProperty("data")]
        // public string Data { get; set; }

        // /// <summary>
        // /// Checks
        // /// </summary>
        // [JsonProperty("is_default")]
        // public bool IsDefault { get; set; }

        // /// <summary>
        // /// V1 Legacy Token
        // /// </summary>
        // [JsonProperty("v1_legacy_token", NullValueHandling = NullValueHandling.Ignore)]
        // public string V1LegacyToken { get; set; }
        

        /// <summary>
        /// TokenEx Token
        /// </summary>
        [JsonProperty("tokenExToken", NullValueHandling = NullValueHandling.Ignore)]
        public string TokenExToken { get; set; }

        /// <summary>
        /// Cardinal's cmpi_lookup response if required.
        /// </summary>
        [JsonProperty("cmpi_lookup_response", NullValueHandling = NullValueHandling.Ignore)]
        public CardinalMPIResponse CardinalMPI { get; set; }

        /// <summary>
        /// CAVV returned from Cardinal
        /// </summary>
        [JsonProperty("cavv", NullValueHandling = NullValueHandling.Ignore)]
        public string CAVV { get; set; }

        /// <summary>
        /// EciFlag returned from Cardinal
        /// </summary>
        [JsonProperty("eciflag", NullValueHandling = NullValueHandling.Ignore)]
        public string ECIFlag { get; set; }

        /// <summary>
        /// Xid returned from Cardinal (Only applicable for AMEX)
        /// </summary>
        [JsonProperty("xid", NullValueHandling = NullValueHandling.Ignore)]
        public string Xid { get; set; }
    }
}