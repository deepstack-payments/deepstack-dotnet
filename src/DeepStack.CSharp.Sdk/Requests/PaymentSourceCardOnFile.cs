using System.ComponentModel;
using DeepStack.Enums;
using Newtonsoft.Json;

namespace DeepStack.Requests
{
    public class PaymentSourceCardOnFile : PaymentSource
    {
        [JsonProperty("card_on_file", Required = Required.Always)]
        public CardOnFile CardOnFile { get; set; }

        public PaymentSourceCardOnFile()
        {
            Type = PaymentSourceType.CARD_ON_FILE;
        }
    }

    public class CardOnFile
    {
        [JsonProperty("id", Required = Required.Always)]
        public string Id;
        
        [JsonProperty("cvv")]
        [Description("The CVV or CVC code usually on the back of the card")]
        public string CVV { get; set; }

        [JsonProperty("customer_id")] 
        [Description("Legacy customer ID, value doesn't matter but we need something")]
        public string CustomerID = "Deprecated";
    }
}