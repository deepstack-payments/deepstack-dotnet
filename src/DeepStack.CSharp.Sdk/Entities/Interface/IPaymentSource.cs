using DeepStack.Enums;
using Newtonsoft.Json;

namespace DeepStack.Entities.Interface
{
    [JsonConverter(typeof(PaymentSourceJsonConverter))]
    public interface IPaymentSource
    {
        PaymentSourceType Type { get; set; }
    }
}