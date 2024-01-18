using DeepStack.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DeepStack.Entities.Common.JSCommon
{
    public class ClientAddress
    {
        [JsonProperty("lineOne")]
        public string Line1 { get; set; }
    
        [JsonProperty("lineTwo")]
        public string Line2 { get; set; }
    
        [JsonProperty("city")]
        public string City { get; set; }
    
        [JsonProperty("state")]
        public string State { get; set; }
    
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
    
        [JsonProperty("country")]
        [JsonConverter(typeof(StringEnumConverter))] 
        public ISO3166CountryCode CountryCode { get; set; }
    }
}