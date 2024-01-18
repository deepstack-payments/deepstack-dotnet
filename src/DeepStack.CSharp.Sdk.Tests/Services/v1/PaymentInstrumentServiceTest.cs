using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DeepStack.Core;
using DeepStack.Entities;
using DeepStack.Entities.Common;
using DeepStack.Extensions;
using DeepStack.Services.v1;
using Xunit;

namespace DeepStack.Tests
{
    public class PaymentInstrumentServiceTest : BaseTest
    {
        private const string BasePath = "/api/v1/vault/payment-instrument";

        private readonly PaymentInstrumentService service;

        public PaymentInstrumentServiceTest(
            MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            service = new PaymentInstrumentService(Client);
        }

        [Fact]
        public void List_Empty()
        {
            var expectedResult = new List<PaymentInstrument>();

            StubRequest(HttpMethod.Get, $"{BasePath}/list/customer_id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.List("customer_id");

            AssertRequest(HttpMethod.Get, $"{BasePath}/list/customer_id");
            Assert.Empty(result);
        }

        [Fact]
        public void List()
        {
            var expectedResult = new List<PaymentInstrument>
            {
                GetPaymentInstrument()
            };

            StubRequest(HttpMethod.Get, $"{BasePath}/list/customer_id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.List("customer_id");

            AssertRequest(HttpMethod.Get, $"{BasePath}/list/customer_id");
            Assert.Collection(result, item =>
                Assert.Equal(expectedResult[0].ToJson(), item.ToJson()));
        }

        [Fact]
        public async Task List_Async()
        {
            var expectedResult = new List<PaymentInstrument>
            {
                GetPaymentInstrument()
            };

            StubRequest(HttpMethod.Get, $"{BasePath}/list/customer_id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.ListAsync("customer_id");

            AssertRequest(HttpMethod.Get, $"{BasePath}/list/customer_id");
            Assert.Collection(result, item =>
                Assert.Equal(expectedResult[0].ToJson(), item.ToJson()));
        }

        [Fact]
        public void List_Error_Invalid_API_Response()
        {
            StubRequest(HttpMethod.Get, $"{BasePath}/list/customer_id", HttpStatusCode.OK, GetInvalidJson());

            var exception = Assert.Throws<DeepStackException>(() =>
               service.List("customer_id"));

            Assert.Equal(HttpStatusCode.OK, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            //Assert.Equal($"Invalid response object from API: \"{GetInvalidJson()}\"", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidJson()}", exception.DeepStackResponse.Content);
        }

        [Fact]
        public void List_Error_Invalid_Status()
        {
            StubRequest(HttpMethod.Get, $"{BasePath}/list/customer_id", HttpStatusCode.BadRequest, GetInvalidStatusError());

            var exception = Assert.Throws<DeepStackException>(() =>
               service.List("customer_id"));

            Assert.Equal(HttpStatusCode.BadRequest, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            Assert.Equal($"{GetInvalidStatusError()}", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidStatusError()}", exception.DeepStackResponse.Content);
        }

        [Fact]
        public void Get_Empty()
        {
            var expectedResult = new PaymentInstrumentCardOnFile();

            StubRequest(HttpMethod.Get, $"{BasePath}/customerId/id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Get("id", "customerId");

            AssertRequest(HttpMethod.Get, $"{BasePath}/customerId/id");
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Get()
        {
            var expectedResult = GetPaymentInstrument();

            StubRequest(HttpMethod.Get, $"{BasePath}/customerId/id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Get("id", "customerId");

            AssertRequest(HttpMethod.Get, $"{BasePath}/customerId/id");
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Get_Async()
        {
            var expectedResult = GetPaymentInstrument();

            StubRequest(HttpMethod.Get, $"{BasePath}/customerId/id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.GetAsync("id", "customerId");

            AssertRequest(HttpMethod.Get, $"{BasePath}/customerId/id");
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Get_Error_Invalid_API_Response()
        {
            StubRequest(HttpMethod.Get, $"{BasePath}/customerId/id", HttpStatusCode.OK, GetInvalidJson());

            var exception = Assert.Throws<DeepStackException>(() =>
               service.Get("id", "customerId"));

            Assert.Equal(HttpStatusCode.OK, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            //Assert.Equal($"Invalid response object from API: \"{GetInvalidJson()}\"", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidJson()}", exception.DeepStackResponse.Content);
        }

        [Fact]
        public void Get_Error_Invalid_Status()
        {
            StubRequest(HttpMethod.Get, $"{BasePath}/customerId/id", HttpStatusCode.BadRequest, GetInvalidStatusError());

            var exception = Assert.Throws<DeepStackException>(() =>
               service.Get("id", "customerId"));

            Assert.Equal(HttpStatusCode.BadRequest, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            Assert.Equal($"{GetInvalidStatusError()}", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidStatusError()}", exception.DeepStackResponse.Content);
        }

        [Fact]
        public void Create()
        {
            var expectedResult = GetPaymentInstrument();

            StubRequest(HttpMethod.Post, $"{BasePath}/{_customerId}", HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Create(GetPaymentInstrumentRequest(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, $"{BasePath}/{_customerId}");
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Create_Async()
        {
            var expectedResult = GetPaymentInstrument();

            StubRequest(HttpMethod.Post, $"{BasePath}/{_customerId}", HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.CreateAsync(GetPaymentInstrument(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, $"{BasePath}/{_customerId}");
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Update()
        {
            var expectedResult = GetPaymentInstrument();

            StubRequest(HttpMethod.Put, $"{BasePath}/{_customerId}/{_Id}", HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Update(GetPaymentInstrument(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Put, $"{BasePath}/{_customerId}/{_Id}");
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Update_Async()
        {
            var expectedResult = GetPaymentInstrument();

            StubRequest(HttpMethod.Put, $"{BasePath}/{_customerId}/{_Id}", HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.UpdateAsync(GetPaymentInstrument(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Put, $"{BasePath}/{_customerId}/{_Id}");
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Update_Error_Invalid_API_Response()
        {
            StubRequest(HttpMethod.Put, $"{BasePath}/{_customerId}/{_Id}", HttpStatusCode.OK, GetInvalidJson());

            var exception = Assert.Throws<DeepStackException>(() =>
               service.Update(GetPaymentInstrument(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.OK, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            //Assert.Equal($"Invalid response object from API: \"{GetInvalidJson()}\"", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidJson()}", exception.DeepStackResponse.Content);
        }

        [Fact]
        public void Update_Error_Invalid_Status()
        {
            StubRequest(HttpMethod.Put, $"{BasePath}/{_customerId}/{_Id}", HttpStatusCode.BadRequest, GetInvalidStatusError());

            var exception = Assert.Throws<DeepStackException>(() =>
              service.Update(GetPaymentInstrument(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.BadRequest, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            Assert.Equal($"{GetInvalidStatusError()}", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidStatusError()}", exception.DeepStackResponse.Content);
        }

        [Fact]
        public void Delete()
        {
            StubRequest(HttpMethod.Delete, $"{BasePath}/{_customerId}/{_Id}", HttpStatusCode.OK, string.Empty);

            service.Delete(_Id, _customerId, GetTestRequestOptions());

            AssertRequest(HttpMethod.Delete, $"{BasePath}/{_customerId}/{_Id}");
        }

        [Fact]
        public async Task Delete_Async()
        {
            StubRequest(HttpMethod.Delete, $"{BasePath}/{_customerId}/{_Id}", HttpStatusCode.OK, string.Empty);

            await service.DeleteAsync(_Id, _customerId, GetTestRequestOptions());

            AssertRequest(HttpMethod.Delete, $"{BasePath}/{_customerId}/{_Id}");
        }
    }
}
