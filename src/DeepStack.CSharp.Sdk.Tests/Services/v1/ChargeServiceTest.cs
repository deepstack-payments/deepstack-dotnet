using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DeepStack.Core;
using DeepStack.Entities;
using DeepStack.Entities.Common;
using DeepStack.Entities.Interface;
using DeepStack.Enums;
using DeepStack.Extensions;
using DeepStack.Requests;
using DeepStack.Services.v1;
using Xunit;

namespace DeepStack.Tests
{
    public class ChargeServiceTest : BaseTest
    {
        private const string BasePath = "/api/v1/payments/charge";

        private readonly ChargeService service;

        public ChargeServiceTest(
            MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            service = new ChargeService(Client);
        }

        [Fact]
        public void Charge_Authorization_Transaction()
        {
            var expectedResult = GetCharge(captured: false);

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Charge(GetChargeRequest(capture: false), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Charge_Async_Authorization_Transaction()
        {
            var expectedResult = GetCharge(captured: false);

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.ChargeAsync(GetChargeRequest(capture: false), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Charge_Sale_Transaction()
        {
            var expectedResult = GetCharge();

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Charge(GetChargeRequest(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Charge_Async_Sale_Transaction()
        {
            var expectedResult = GetCharge();

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.ChargeAsync(GetChargeRequest(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Charge_With_Payment_Instrument_Transaction()
        {
            var expectedResult = GetCharge(savePaymentInstrument: true);

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Charge(GetChargeRequest(savePaymentInstrument: true), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Charge_Async_With_Payment_Instrument_Transaction()
        {
            var expectedResult = GetCharge(savePaymentInstrument: true);

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.ChargeAsync(GetChargeRequest(savePaymentInstrument: true), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Charge_Error_Invalid_API_Response()
        {
            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, GetInvalidJson());

            var exception = Assert.Throws<DeepStackException>(() =>
               service.Charge(GetChargeRequest(), GetTestRequestOptions()));

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
               service.Charge(GetChargeRequest(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.BadRequest, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            Assert.Equal($"{GetInvalidStatusError()}", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidStatusError()}", exception.DeepStackResponse.Content);
        }

        private ChargeRequest GetChargeRequest(bool capture = true, bool savePaymentInstrument = false)
        {
            return new ChargeRequest
            {
                Source = new PaymentSourceCardOnFile()
                {
                    Type = PaymentSourceType.CARD_ON_FILE,
                    CardOnFile = new CardOnFile()
                    {
                        Id = "token_id",
                        CVV = "" // optional
                    }
                    
                },
                Params = new TransactionParameters()
                {
                    Amount = 1299,
                    Capture = true
                }
            };
        }

        private ChargeResponse GetCharge(bool captured = true, bool savePaymentInstrument = false)
        {
            return new ChargeResponse()
            {
                ID = "id",
                Source = new PaymentSourceRawCard()
                { 
                    Type = PaymentSourceType.CARD_ON_FILE,
                    Id = "id"
                },
                Amount = 1299,
                ResponseCode = "00",
                Message = "charged",
                Approved = true,
                Captured = captured,
                NewPaymentInstrument = savePaymentInstrument ? GetPaymentInstrument() : null,
                Checks = new Checks()
                {
                    CvcCheck = "Y",
                    AddressLine1Check = "Y",
                    AddressPostalCodeCheck = "Y"
                },
                Response = "",
                AuthCode = "df23412",
                BillingContact = new BillingContact()
                {
                    Address = new Address()
                    {
                        Line1 = "1234 Some St",
                        City = "Anywhere",
                        State = "CA",
                        PostalCode = "12345",
                        CountryCode = ISO3166CountryCode.USA
                    },
                    Email = "jdoe@example.com",
                    Phone = "7145551212",
                    FirstName = "John",
                    LastName = "Doe"
                },
                CofType = CofType.UNSCHEDULED_CARDHOLDER,
                CountryCode = ISO3166CountryCode.USA,
                CurrencyCode = CurrencyCode.USD,
                ShippingContact = new ShippingContact()
                {
                    Address = new Address()
                    {
                        Line1 = "1234 Some St",
                        City = "Anywhere",
                        State = "CA",
                        PostalCode = "12345",
                        CountryCode = ISO3166CountryCode.USA
                    },
                    Email = "jdoe@example.com",
                    Phone = "7145551212",
                    FirstName = "John",
                    LastName = "Doe"
                },
                ClientTransactionDescription = "E-comm order",
                SavePaymentInstrument = true,
                ClientInvoiceID = "US-INV-1234512",
                ClientTransactionID = "asdf-qwueia-asf12351w"
            };
        }

        private ChargeResponse GetChargeWithInvalidResponseCode()
        {
            return new ChargeResponse()
            {
                ID = "id",
                Amount = 1299,
                ResponseCode = "02",
                Message = "Not Approved"
            };
        }
    }
}
