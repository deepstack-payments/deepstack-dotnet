using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DeepStack.Core;
using DeepStack.Entities;
using DeepStack.Extensions;
using DeepStack.Requests;
using DeepStack.Services.v1;
using Xunit;

namespace DeepStack.Tests
{
    public class CaptureServiceTest : BaseTest
    {
        private const string BasePath = "/api/v1/payments/capture";

        private readonly CaptureService service;

        public CaptureServiceTest(
            MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            service = new CaptureService(Client);
        }

        [Fact]
        public void Capture()
        {
            var expectedResult = GetCapture();

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Capture(GetCaptureRequest(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Capture_Async()
        {
            var expectedResult = GetCapture();

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.CaptureAsync(GetCaptureRequest(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Capture_Error_Invalid_ResponseCode()
        {
            var expectedResult = GetCaptureWithInvalidResponseCode();

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var exception = Assert.Throws<DeepStackException>(() =>
                service.Capture(GetCaptureRequest(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.BadRequest, exception.HttpStatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            Assert.Equal("Not Approved", exception.ErrorMessage);
        }

        [Fact]
        public void Capture_Error_Invalid_API_Response()
        {
            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, GetInvalidJson());

            var exception = Assert.Throws<DeepStackException>(() =>
               service.Capture(GetCaptureRequest(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.OK, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            //Assert.Equal($"Invalid response object from API: \"{GetInvalidJson()}\"", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidJson()}", exception.DeepStackResponse.Content);
        }

        [Fact]
        public void Capture_Error_Invalid_Status()
        {
            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.BadRequest, GetInvalidStatusError());

            var exception = Assert.Throws<DeepStackException>(() =>
               service.Capture(GetCaptureRequest(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.BadRequest, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            Assert.Equal($"{GetInvalidStatusError()}", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidStatusError()}", exception.DeepStackResponse.Content);
        }

        private CaptureRequest GetCaptureRequest()
        {
            return new CaptureRequest
            {
                Charge = "charge_id",
                Amount = 1299
            };
        }

        private Capture GetCapture()
        {
            return new Capture
            {
                ChargeTransactionId = "charge_transaction_id",
                ResponseCode = "00",
                Amount = 1299,
                Message = "captured",
                Approved = true
            };
        }

        private Capture GetCaptureWithInvalidResponseCode()
        {
            return new Capture
            {
                ChargeTransactionId = "charge_transaction_id",
                ResponseCode = "02",
                Amount = 1299,
                Message = "Not Approved"
            };
        }
    }
}
