using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DeepStack.Core;
using DeepStack.Entities;
using DeepStack.Entities.Common;
using DeepStack.Enums;
using DeepStack.Extensions;
using DeepStack.Services.v1;
using Xunit;

namespace DeepStack.Tests
{
    public class CustomerServiceTest : BaseTest
    {
        private const string BasePath = "/api/v1/vault/customer";

        private readonly CustomerService service;

        public CustomerServiceTest(
            MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            service = new CustomerService(Client);
        }

        [Fact]
        public void List_Empty()
        {
            var expectedResult = new List<Customer>();

            StubRequest(HttpMethod.Get, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.List();

            AssertRequest(HttpMethod.Get, BasePath);
            Assert.Empty(result);
        }

        [Fact]
        public void List()
        {
            var expectedResult = new List<Customer>
            {
                GetCustomer()
            };

            StubRequest(HttpMethod.Get, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.List();

            AssertRequest(HttpMethod.Get, BasePath);
            Assert.Collection(result, item => 
                Assert.Equal(expectedResult[0].ToJson(), item.ToJson()));
        }

        [Fact]
        public async Task List_Async()
        {
            var expectedResult = new List<Customer>
            {
                GetCustomer()
            };

            StubRequest(HttpMethod.Get, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.ListAsync();

            AssertRequest(HttpMethod.Get, BasePath);
            Assert.Collection(result, item =>
                Assert.Equal(expectedResult[0].ToJson(), item.ToJson()));
        }

        [Fact]
        public void List_Error_Invalid_API_Response()
        {
            StubRequest(HttpMethod.Get, BasePath, HttpStatusCode.OK, GetInvalidJson());

            var exception = Assert.Throws<DeepStackException>(() =>
               service.List());

            Assert.Equal(HttpStatusCode.OK, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            //Assert.Equal($"Invalid response object from API: \"{GetInvalidJson()}\"", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidJson()}", exception.DeepStackResponse.Content);
        }

        [Fact]
        public void List_Error_Invalid_Status()
        {
            StubRequest(HttpMethod.Get, BasePath, HttpStatusCode.BadRequest, GetInvalidStatusError());

            var exception = Assert.Throws<DeepStackException>(() =>
               service.List());

            Assert.Equal(HttpStatusCode.BadRequest, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            Assert.Equal($"{GetInvalidStatusError()}", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidStatusError()}", exception.DeepStackResponse.Content);
        }

        [Fact]
        public void Get_Empty()
        {
            var expectedResult = new Customer();

            StubRequest(HttpMethod.Get, $"{BasePath}/id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Get("id");

            AssertRequest(HttpMethod.Get, $"{BasePath}/id");
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Get()
        {
            var expectedResult = GetCustomer();

            StubRequest(HttpMethod.Get, $"{BasePath}/id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Get("id");

            AssertRequest(HttpMethod.Get, $"{BasePath}/id");
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Get_Async()
        {
            var expectedResult = GetCustomer();

            StubRequest(HttpMethod.Get, $"{BasePath}/id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.GetAsync("id");

            AssertRequest(HttpMethod.Get, $"{BasePath}/id");
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Get_Error_Invalid_API_Response()
        {
            StubRequest(HttpMethod.Get, $"{BasePath}/id", HttpStatusCode.OK, GetInvalidJson());

            var exception = Assert.Throws<DeepStackException>(() =>
               service.Get("id"));

            Assert.Equal(HttpStatusCode.OK, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            //Assert.Equal($"Invalid response object from API: \"{GetInvalidJson()}\"", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidJson()}", exception.DeepStackResponse.Content);
        }

        [Fact]
        public void Get_Error_Invalid_Status()
        {
            StubRequest(HttpMethod.Get, $"{BasePath}/id", HttpStatusCode.BadRequest, GetInvalidStatusError());

            var exception = Assert.Throws<DeepStackException>(() =>
               service.Get("id"));

            Assert.Equal(HttpStatusCode.BadRequest, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            Assert.Equal($"{GetInvalidStatusError()}", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidStatusError()}", exception.DeepStackResponse.Content);
        }

        [Fact]
        public void Create()
        {
            var expectedResult = GetCustomer();

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Create(GetCustomer(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Create_Async()
        {
            var expectedResult = GetCustomer();

            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.CreateAsync(GetCustomer(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Post, BasePath);
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Create_Error_Invalid_API_Response()
        {
            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.OK, GetInvalidJson());

            var exception = Assert.Throws<DeepStackException>(() =>
               service.Create(GetCustomer(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.OK, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            //Assert.Equal($"Invalid response object from API: \"{GetInvalidJson()}\"", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidJson()}", exception.DeepStackResponse.Content);
        }

        [Fact]
        public void Create_Error_Invalid_Status()
        {
            StubRequest(HttpMethod.Post, BasePath, HttpStatusCode.BadRequest, GetInvalidStatusError());

            var exception = Assert.Throws<DeepStackException>(() =>
              service.Create(GetCustomer(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.BadRequest, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            Assert.Equal($"{GetInvalidStatusError()}", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidStatusError()}", exception.DeepStackResponse.Content);
        }

        [Fact]
        public void Update()
        {
            var expectedResult = GetCustomer();

            StubRequest(HttpMethod.Put, $"{BasePath}/id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = service.Update(GetCustomer(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Put, $"{BasePath}/id");
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public async Task Update_Async()
        {
            var expectedResult = GetCustomer();

            StubRequest(HttpMethod.Put, $"{BasePath}/id", HttpStatusCode.OK, expectedResult.ToJson());

            var result = await service.UpdateAsync(GetCustomer(), GetTestRequestOptions());

            AssertRequest(HttpMethod.Put, $"{BasePath}/id");
            Assert.Equal(expectedResult.ToJson(), result.ToJson());
        }

        [Fact]
        public void Update_Error_Invalid_API_Response()
        {
            StubRequest(HttpMethod.Put, $"{BasePath}/id", HttpStatusCode.OK, GetInvalidJson());

            var exception = Assert.Throws<DeepStackException>(() =>
               service.Update(GetCustomer(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.OK, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            //Assert.Equal($"Invalid response object from API: \"{GetInvalidJson()}\"", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidJson()}", exception.DeepStackResponse.Content);
        }

        [Fact]
        public void Update_Error_Invalid_Status()
        {
            StubRequest(HttpMethod.Put, $"{BasePath}/id", HttpStatusCode.BadRequest, GetInvalidStatusError());

            var exception = Assert.Throws<DeepStackException>(() =>
              service.Update(GetCustomer(), GetTestRequestOptions()));

            Assert.Equal(HttpStatusCode.BadRequest, exception.DeepStackResponse.StatusCode);
            Assert.Equal("Exception of type 'GloballyPaid.DeepStackException' was thrown.", exception.Message);
            Assert.Equal($"{GetInvalidStatusError()}", exception.ErrorMessage);
            Assert.Equal($"{GetInvalidStatusError()}", exception.DeepStackResponse.Content);
        }

        [Fact]
        public void Delete()
        {
            StubRequest(HttpMethod.Delete, $"{BasePath}/id", HttpStatusCode.OK, string.Empty);

            service.Delete("id", GetTestRequestOptions());

            AssertRequest(HttpMethod.Delete, $"{BasePath}/id");
        }

        [Fact]
        public async Task Delete_Async()
        {
            StubRequest(HttpMethod.Delete, $"{BasePath}/id", HttpStatusCode.OK, string.Empty);

            await service.DeleteAsync("id", GetTestRequestOptions());

            AssertRequest(HttpMethod.Delete, $"{BasePath}/id");
        }

        private Customer GetCustomer()
        {
            return new Customer
            {
                Id = "id",
                ClientCustomerId = "0000000",
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
            };
        }
    }
}
