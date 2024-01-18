using System;
using DeepStack.Entities.Common;
using Newtonsoft.Json.Linq;

namespace DeepStack.Entities
{
    public class PaymentInstrumentJsonConverter : ModelBinderJsonConverter<PaymentInstrument>
    {
        protected override PaymentInstrument Create(Type objType, JObject jObject)
        {
            if (objType == null) throw new ArgumentNullException(nameof(objType));
            
            // backwards compatible JSON names for JS SDK
            if (jObject["type"] != null && jObject["type"].Value<string>().Equals("credit_card", StringComparison.OrdinalIgnoreCase))
                return new PaymentInstrumentCardOnFile();

            if (jObject["type"] != null && jObject["type"].Value<string>().Equals("card_on_file", StringComparison.OrdinalIgnoreCase))
                return new PaymentInstrumentCardOnFile();

            return null;
        }
    }
}