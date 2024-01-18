using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DeepStack.Core;

namespace DeepStack.Tests
{
    public class MockHttpClientFixture
    {
        public MockHttpClientFixture()
        {
            MockHandler = new Mock<HttpMessageHandler>();
            HttpClient = new HttpServiceClient(new HttpClient(MockHandler.Object));
        }

        public Mock<HttpMessageHandler> MockHandler { get; }

        public HttpServiceClient HttpClient { get; }

        public void Reset()
        {
            MockHandler.Reset();
        }

        public void AssertRequest(HttpMethod method, string path)
        {
            MockHandler.Protected()
                .Verify(
                    "SendAsync",
                    Times.Once(),
                    ItExpr.Is<HttpRequestMessage>(m =>
                        m.Method == method &&
                        m.RequestUri.AbsolutePath == path),
                    ItExpr.IsAny<CancellationToken>());
        }

        public void StubRequest(HttpMethod method, string path, HttpStatusCode status, string response)
        {
            var responseMessage = new HttpResponseMessage(status)
            {
                Content = new StringContent(response)
            };

            MockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(m =>
                        m.Method == method &&
                        m.RequestUri.AbsolutePath == path),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(responseMessage)
               .Verifiable();
        }
    }
}
