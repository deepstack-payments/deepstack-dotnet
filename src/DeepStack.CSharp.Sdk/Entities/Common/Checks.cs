using Newtonsoft.Json;

namespace DeepStack.Entities.Common
{
    public class Checks
    {
        /// <summary>
        /// Checks
        /// </summary>
        [JsonProperty("address_line1_check")]
        public string AddressLine1Check { get; set; }

        /// <summary>
        /// Checks
        /// </summary>
        [JsonProperty("address_postal_code_check")]
        public string AddressPostalCodeCheck { get; set; }

        /// <summary>
        /// Checks
        /// </summary>
        [JsonProperty("cvc_check")]
        public string CvcCheck { get; set; }
    }
}