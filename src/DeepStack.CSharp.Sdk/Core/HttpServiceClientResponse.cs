using System.Net;
using System.Net.Http.Headers;

namespace DeepStack.Core
{
    public class HttpServiceClientResponse
    {
        public HttpServiceClientResponse(HttpStatusCode statusCode, HttpResponseHeaders headers, string content)
        {
            StatusCode = statusCode;
            Headers = headers;
            Content = content;
        }

        /// <summary>Gets the HTTP status code of the response.</summary>
        /// <value>The HTTP status code of the response.</value>
        public HttpStatusCode StatusCode { get; }

        /// <summary>Gets the HTTP headers of the response.</summary>
        /// <value>The HTTP headers of the response.</value>
        public HttpResponseHeaders Headers { get; }

        /// <summary>Gets the body of the response.</summary>
        /// <value>The body of the response.</value>
        public string Content { get; }
    }
}
