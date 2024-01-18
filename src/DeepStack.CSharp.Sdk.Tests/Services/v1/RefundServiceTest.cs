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
    public class RefundServiceTest : BaseTest
    {
        private const string BasePath = "/api/v1/payments/refund";

        private readonly RefundService service;

        public RefundServiceTest(
            MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            service = new RefundService(Client);
        }

        [Fact]
        public void Refund()
        {
            var expectedResult = GetRefund();

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Refund(GetRefundRequest(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Refund_Async()
        {
            var expectedResult = GetRefund();

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.RefundAsync(GetRefundRequest(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Refund_Error_Invalid_ResponseCode()
        {
            var expectedResult = GetRefundWithInvalidResponseCode();

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var exception = Assert.Throws<DeepStackException>(() =>
                service.Refund(GetRefundRequest(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.BadRequest, exception.HttpStatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            Assert.Equal("Not Approved", exception.ErrorMessage);
        }

        [Fact]
        public void Refund_Error_Invalid_API_Response()
        {
            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, GetInvalidJson());

            var exception = Assert.Throws<DeepStackException>(() =>
               service.Refund(GetRefundRequest(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.OK, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            //Assert.Equal($"Invalid response object from API: \"{GetInvalidJson()}\"", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidJson()}", exception.DeepStackResponse.Content);
        }

        [Fact]
        public void Refund_Error_Invalid_Status()
        {
            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.BadRequest, GetInvalidStatusError());

            var exception = Assert.Throws<DeepStackException>(() =>
               service.Refund(GetRefundRequest(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.BadRequest, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            Assert.Equal($"{GetInvalidStatusError()}", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidStatusError()}", exception.DeepStackResponse.Content);
        }

        private RefundRequest GetRefundRequest()
        {
            return new RefundRequest
            {
                Charge = "charge_id",
                Amount = 1299
            };
        }

        private Refund GetRefund()
        {
            return new Refund
            {
                Id = "id",
                ChargeTransactionId = "charge_transaction_id",
                ResponseCode = "00",
                Amount = 1299,
                Message = "refunded",
                Approved = true,
                Success = true
            };
        }

        private Refund GetRefundWithInvalidResponseCode()
        {
            return new Refund
            {
                Id = "id",
                ChargeTransactionId = "charge_transaction_id",
                ResponseCode = "02",
                Amount = 1299,
                Message = "Not Approved",
            };
        }
    }
}
