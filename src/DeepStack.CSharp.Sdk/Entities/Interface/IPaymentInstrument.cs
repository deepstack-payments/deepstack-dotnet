using DeepStack.Entities.Common;
using DeepStack.Enums;
using Newtonsoft.Json;

namespace DeepStack.Entities.Interface
{
    [JsonConverter(typeof(PaymentInstrumentJsonConverter))]
    public interface IPaymentInstrument
    {
        string Id { get; }
        PaymentSourceType Type { get; set; }
        string CustomerId { get; set; }
        string ClientCustomerId { get; set; }
        BillingContact BillingContact { get; set; }
    }
}