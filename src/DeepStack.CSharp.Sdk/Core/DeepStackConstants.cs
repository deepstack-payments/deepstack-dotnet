using System.Collections.Generic;
using System.Net;

namespace DeepStack.Core
{
    internal static class DeepStackConstants
    {
        public const string DefaultBaseUrl = "https://api.deepstack.io";
        public const string DefaultSandboxBaseUrl = "https://api.sandbox.deepstack.io";

        public static readonly string ApplicationJson = "application/json";
        public static readonly string BearerAuthenticationScheme = "Bearer";
        public const int DefaultTimoutSeconds = 30;

        public static readonly IReadOnlyDictionary<HttpStatusCode, string> ErrorStatusCodes
           = new Dictionary<HttpStatusCode, string>
       {
            { HttpStatusCode.Unauthorized, "Your API key is wrong." },
            { HttpStatusCode.Forbidden, "The endpoint requested is hidden for administrators only." },
            { HttpStatusCode.NotFound, "The specified endpoint could not be found." },
            { HttpStatusCode.MethodNotAllowed, "You tried to access a request with an invalid method." },
            { HttpStatusCode.NotAcceptable, "You requested a format that isn't json." },
            { HttpStatusCode.Gone, " The endpoint requested has been removed from our servers." },
            { HttpStatusCode.InternalServerError, "We had a problem with our server. Try again later." },
            { HttpStatusCode.ServiceUnavailable, "We're temporarily offline for maintenance. Please try again later." }
       };
    }
}
