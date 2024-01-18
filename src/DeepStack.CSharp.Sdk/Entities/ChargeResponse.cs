using System.Collections.Generic;
using System.ComponentModel;
using DeepStack.Entities.Common;
using DeepStack.Entities.Interface;
using DeepStack.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DeepStack.Entities
{
    public class ChargeResponse
    {
        
        [JsonProperty("id")]
        [Description("Charge transaction ID with successful charge request")]
        public string ID { get; set; }
        
        [JsonProperty("response_code")]
        [Description("Deepstack response code")]
        public string ResponseCode { get; set; }
        
        [JsonProperty("message")]
        [Description("Response message associated with response code")]
        public string Message { get; set; }
        public string Response { get; set; }
        
        [JsonProperty("approved")]
        [Description("Approved flag")]
        public bool Approved { get; set; }
        
        [JsonProperty("auth_code")]
        [Description("Authorization code from Deepstack backend processor")]
        public string AuthCode { get; set; }
        
        [JsonProperty("source")]
        [Description("The payment source that was charged")]
        [JsonConverter(typeof(PaymentSourceJsonConverter))]
        public IPaymentSource Source{ get; set; }

        [JsonProperty("amount")]
        [Description("The original amount of the transaction in cents")]
        public int Amount { get; set; }

        [JsonProperty("captured")]
        [Description("Whether or not this Charge was captured (sale) or not (authorization)")]
        public bool Captured { get; set; }

        /// <summary>
        /// Specifies cof types of the transaction: UNSCHEDULED_CARDHOLDER | UNSCHEDULED_MERCHANT | RECURRING | INSTALLMENT
        /// </summary>
        [JsonProperty("cof_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CofType? CofType { get; set; }

        [JsonProperty("currency_code")]
        [Description("The ISO currency code for the transaction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCode CurrencyCode { get; set; }

        [JsonProperty("country_code")]
        [Description("The ISO country code of the transaction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ISO3166CountryCode CountryCode { get; set; }

        [JsonProperty("billing_info")]
        [Description("Billing information of the card holder")]
        public BillingContact BillingContact { get; set; }

        [JsonProperty("shipping_info", NullValueHandling = NullValueHandling.Ignore)]
        [Description("Shpping information for the transaction (if supplied in original transaction)")]
        public ShippingContact ShippingContact { get; set; }

        [JsonProperty("client_transaction_id")]
        [Description("The company's transaction Id")]
        public string ClientTransactionID { get; set; }

        [JsonProperty("client_transaction_description")]
        [Description("The company's transaction description used in the transaction")]
        public string ClientTransactionDescription { get; set; }

        [JsonProperty("client_invoice_id")]
        [Description("The company's invoice Id for the transaction")]
        public string ClientInvoiceID { get; set; }

        /// <summary>
        /// Indicates if the charge request specified to save the payment instrument
        /// </summary>
        [JsonProperty("save_payment_instrument", NullValueHandling = NullValueHandling.Ignore)]
        public bool SavePaymentInstrument { get; set; }

        /// <summary>
        /// If save_payment_instrument is true and the transaction succeeded,
        /// this field will contain the newly created PaymentInstrument
        /// </summary>
        [JsonProperty("new_payment_instrument", NullValueHandling = NullValueHandling.Ignore)]
        public IPaymentInstrument NewPaymentInstrument { get; set; }

        /// <summary>
        /// The company's Kount check score
        /// </summary>
        [JsonProperty("kount_score")]
        [Description("The company's Kount check score")]
        public string KountScore { get; set; }

        /// <summary>
        /// Checks
        /// </summary>
        [JsonProperty("checks")]
        public Checks Checks { get; set; }

        /// <summary>
        /// Errors
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore, Order = 1000)]
        [Description("Error(s) that happened during the processing of the request")]
        public List<Error> Errors { get; set; }
    }
}

