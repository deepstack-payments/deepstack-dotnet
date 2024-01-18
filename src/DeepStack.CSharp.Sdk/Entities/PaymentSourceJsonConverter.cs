using System;
using DeepStack.Requests;
using Newtonsoft.Json.Linq;

namespace DeepStack.Entities
{
    public class PaymentSourceJsonConverter: ModelBinderJsonConverter<PaymentSource>
    {
        protected override PaymentSource Create(Type objType, JObject jObject)
        {
            if (objType == null) throw new ArgumentNullException(nameof(objType));
            
            // backwards compatible JSON names for JS SDK
            if (jObject["type"] != null && jObject["type"].Value<string>().Equals("credit_card", StringComparison.OrdinalIgnoreCase))
                return new PaymentSourceRawCard();

            if (jObject["type"] != null && jObject["type"].Value<string>().Equals("card_on_file", StringComparison.OrdinalIgnoreCase))
                return new PaymentSourceCardOnFile();

            return null;
        }
    }    
}
