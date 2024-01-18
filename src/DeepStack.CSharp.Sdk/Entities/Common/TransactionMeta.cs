using Newtonsoft.Json;

namespace DeepStack.Entities.Common
{
    public class TransactionMeta
    {
        /// <summary>
        /// A unique identifier for the transaction in the Company's system.
        /// </summary>
        [JsonProperty("client_transaction_id")]
        public string ClientTransactionID { get; set; }
        
        /// <summary>
        /// A unique identifier for the customer in the Company's system.
        /// </summary>
        [JsonProperty("client_customer_id")]
        public string ClientCustomerID { get; set; }

        /// <summary>
        /// A short description for this charge
        /// </summary>
        [JsonProperty("client_transaction_description")]
        public string ClientTransactionDescription { get; set; }

        /// <summary>
        /// The Company's invoice number/id for this charge
        /// </summary>
        [JsonProperty("client_invoice_id")]
        public string ClientInvoiceID { get; set; }
        
        /// <summary>
        /// Card holder billing information
        /// </summary>
        /// <summary>
        /// Shipping information for this charge
        /// </summary>
        [JsonProperty("shipping_info", NullValueHandling = NullValueHandling.Ignore)]
        public ShippingContact ShippingContact { get; set; }
        
    }
}