using DeepStack.Entities.Base;
using Newtonsoft.Json;

namespace DeepStack.Entities.Common
{
    public class Contact : Entity
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}
