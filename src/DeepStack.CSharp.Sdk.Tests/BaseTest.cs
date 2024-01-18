using System;
using System.Net;
using System.Net.Http;
using DeepStack.Core;
using DeepStack.Entities;
using DeepStack.Entities.Common;
using DeepStack.Enums;
using DeepStack.Requests;
using DeepStack.Requests.Base;
using Xunit;

namespace DeepStack.Tests
{
    [Collection("Globally Paid SDK tests")]
    public class BaseTest
    {
        protected string _Id = "card_981234kjsdf8913";
        protected string _customerId = "cus_981234kjsdf8913";
        protected HttpServiceClient Client { get; }

        protected MockHttpClientFixture MockHttpClientFixture { get; }

        public BaseTest(MockHttpClientFixture mockHttpClientFixture)
        {
            MockHttpClientFixture = mockHttpClientFixture;

            var httpClient = new HttpServiceClient(
                new HttpClient(MockHttpClientFixture.MockHandler.Object)
                {
                    BaseAddress = new Uri("https://sandbox.transactions.globallypaid.com")
                });
            Client = new HttpServiceClient(httpClient);

            MockHttpClientFixture.Reset();
        }

        protected void AssertRequest(HttpMethod method, string path)
        {
            MockHttpClientFixture.AssertRequest(method, path);
        }

        protected void StubRequest(HttpMethod method, string path, HttpStatusCode status, string response)
        {
            MockHttpClientFixture.StubRequest(method, path, status, response);
        }

        protected RequestOptions GetTestRequestOptions()
        {
            return new RequestOptions("Test Publishable API Key", "Test Shared Secret", "Test APP ID");
        }

        protected string GetInvalidJson()
        {
            return "{\"errors: \"invalid JSON\"}";
        }

        protected string GetInvalidStatusError()
        {
            return "{\"error\": \"invalid status\"}";
        }

        protected PaymentInstrumentRequest GetPaymentInstrumentRequest()
        {
            return new PaymentInstrumentRequest
            {
                Id = "id",
                Type = PaymentType.CreditCard,
                CustomerId = _customerId,
                ClientCustomerId = "000000",
                CreditCard = new CreditCard
                {
                    Number = "4111111111111111",
                    CVV = "123",
                    Brand = "Visa",
                    Expiration = "0725",
                    LastFour = "1111"
                },
                BillingContact = new Contact
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Address = new Address
                    {
                        Line1 = "Address Line 1",
                        City = "CIty",
                        State = "State",
                        PostalCode = "00000",
                        CountryCode = ISO3166CountryCode.USA
                    },
                    Email = "jane.doe@example.com",
                    Phone = "0000000000"
                }
            };
        }

        protected PaymentInstrumentCardOnFile GetPaymentInstrument(bool forCreate = false)
        {
            return new PaymentInstrumentCardOnFile()
            {
                Id = forCreate ? null : _Id,
                Type = PaymentSourceType.CARD_ON_FILE,
                CustomerId = _customerId,
                ClientCustomerId = "000000",
                Brand = "Visa",
                Expiration = "0725",
                LastFour = "1111",
                BIN = "411111",
                BillingContact = new BillingContact()
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Address = new Address
                    {
                        Line1 = "Address Line 1",
                        City = "CIty",
                        State = "State",
                        PostalCode = "00000",
                        CountryCode = ISO3166CountryCode.USA
                    },
                    Email = "jane.doe@example.com",
                    Phone = "0000000000"
                },
                IsDefault = false
            };
        }
    }
}
