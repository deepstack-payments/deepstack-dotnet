using System;
using DeepStack.Entities.Common;
using DeepStack.Enums;
using Newtonsoft.Json;

namespace DeepStack.Entities
{
    
    public class PaymentInstrumentCardOnFile : PaymentInstrument
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PaymentInstrumentCardOnFile()
        {
            Type = PaymentSourceType.CARD_ON_FILE;
            Created = Updated = DateTime.UtcNow;
        }

        /// <summary>
        /// Customer Id
        /// </summary>
        [JsonProperty("customer_id", Order = 1)]
        public override string CustomerId { get; set; }

        /// <summary>
        /// Client Id
        /// </summary>
        [JsonIgnore]
        [JsonProperty("client_id", Order = 2)]
        public override string ClientId { get; set; }

        /// <summary>
        /// ClientCustomer Id
        /// </summary>
        [JsonProperty("client_customer_id", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
        public override string ClientCustomerId { get; set; }

        /// <summary>
        /// The brand of the credit card, eg: Visa, Mastercard, Discover, Amex
        /// </summary>
        [JsonProperty("brand", Order = 4, NullValueHandling = NullValueHandling.Ignore)]
        public string Brand { get; set; }

        /// <summary>
        /// The BIN of the account number
        /// </summary>
        [JsonProperty("bin", Order = 5)]
        public string BIN { get; set; }
        
        /// <summary>
        /// The last four digits of the account number
        /// </summary>
        [JsonProperty("last_four", Order = 6)]
        public string LastFour { get; set; }

        /// <summary>
        /// If a card, the card expiration. Blank if BankAccount.
        /// </summary>
        [JsonProperty("expiration", Order = 7)]
        public string Expiration { get; set; }

        /// <summary>
        /// Provided from JS SDK for third party fraud checks.
        /// </summary>
        [JsonIgnore]
        [JsonProperty("kount_session_id", Order = 8)]
        public string KountSessionId { get; set; }

        /// <summary>
        /// Billing Contact
        /// </summary>
        [JsonProperty("billing_contact", Order = 9)]
        public override BillingContact BillingContact { get; set; }

        /// <summary>
        /// Created
        /// </summary>
        [JsonIgnore]
        [JsonProperty("created", Order = 10)]
        public override DateTime Created { get; set; }

        /// <summary>
        /// Updated
        /// </summary>
        [JsonIgnore]
        [JsonProperty("updated", Order = 11)]
        public override DateTime Updated { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        [JsonIgnore]
        [JsonProperty("data", Order = 12)]
        public override string Data { get; set; }

        /// <summary>
        /// Checks
        /// </summary>
        [JsonProperty("is_default", Order = 13)]
        public bool IsDefault { get; set; }

        /// <summary>
        /// V1 Legacy Token
        /// </summary>
        [JsonProperty("v1_legacy_token", Order = 14, NullValueHandling = NullValueHandling.Ignore)]
        public string V1LegacyToken { get; set; }

        /// <summary>
        /// Original Network Transaction Identifier - Processor TransactionID from Deepstack
        /// </summary>
        [JsonIgnore]
        [JsonProperty("original_network_transaction_identifier")]
        public override string OriginalNetworkTransactionIdentifier { get; set; }

        /// <summary>
        /// TokenEx Token
        /// </summary>
        [JsonProperty("token_ex_token", NullValueHandling = NullValueHandling.Ignore)]
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