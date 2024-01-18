using Newtonsoft.Json;

namespace DeepStack.Entities.Common.JSCommon
{
    public class ClientBillingContact
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
    
        [JsonProperty("lastName")]
        public string LastName { get; set; }
    
        [JsonProperty("address")]
        public ClientAddress Address { get; set; }
    
        [JsonProperty("phone")]
        public string Phone { get; set; }
    
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}