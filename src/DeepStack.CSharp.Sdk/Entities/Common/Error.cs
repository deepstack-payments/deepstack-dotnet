using Newtonsoft.Json;

namespace DeepStack.Entities.Common
{
    public class Error
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        public Error(string message, string code = "3")
        {
            Message = message;
            Code = code;
        }

        public Error() : this("Unknown error ocurred") { }
    }
}