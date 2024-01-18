using DeepStack.Entities.Base;
using DeepStack.Enums;
using Newtonsoft.Json;

namespace DeepStack.Entities.Common
{
    public class Address : Entity
    {
        [JsonProperty("line_1")]
        public string Line1 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country_code")]
        public ISO3166CountryCode CountryCode { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
    }
}
