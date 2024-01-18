using System.ComponentModel;
using DeepStack.Entities.Base;
using Newtonsoft.Json;

namespace DeepStack.Entities.Common
{
    public class CreditCard : Entity
    {
        private string _accountNumber;

        // for backwards compatibility
        [JsonProperty("account_number", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [Description("The full credit card number. Not non-numeric values will be stripped")]
        public string Number
        {
            get => _accountNumber;
            set => _accountNumber = value;
        }

        [JsonProperty("expiration", Required = Required.Always)]
        [Description("The expiration date on the card (mmyy)")]
        public string Expiration { get; set; }

        [JsonProperty("cvv", NullValueHandling = NullValueHandling.Ignore)]
        [Description("The CVV or CVC code usually on the back of the card")]
        public string CVV { get; set; }

        [JsonProperty("brand")]
        [Description("The card type, or brand, of the card. EX: Visa, Mastercard, AMEX, Discover")]
        public string Brand { get; set; }

        [JsonProperty("last_four")]
        [Description("The last 4 digits of the card number")]
        public string LastFour { get; set; }

        [JsonIgnore]
        [Description("The BIN number for the card.")]
        public string BIN
        {
            get { return Number.Substring(0, 6);}
        }
    }
}
