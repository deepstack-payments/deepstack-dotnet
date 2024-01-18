using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DeepStack.Core;
using DeepStack.Entities;
using DeepStack.Requests.Base;
using DeepStack.Services.Base;
using DeepStack.Services.v1.Interfaces;

namespace DeepStack.Services.v1
{
    /// <summary>
    /// Service for Create, Read, Update and Delete of the <see cref="Customer"/> entity
    /// </summary>
    public class CustomerService : Service, ICustomerService
    {
        public CustomerService() { }

        public CustomerService(HttpServiceClient client) : base(client) { }

        protected override string BasePath => $"api/v1/vault/customer";

        /// <summary>
        /// Sends a request to Globally Paid API to get all customers
        /// </summary>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A list of <see cref="Customer"/> entities</returns>
        public List<Customer> List(RequestOptions requestOptions = null)
        {
            TryReconfigureClient(requestOptions);
            return Client.Get<List<Customer>>(BasePath);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to get all customers, as an asynchronous operation
        /// </summary>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A list of <see cref="Customer"/> Task entities, representing the asynchronous operation</returns>
        public async Task<List<Customer>> ListAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(requestOptions);
            return await Client.GetAsync<List<Customer>>(BasePath, checkResponseCode: false, cancellationToken);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to get a particular customer by id
        /// </summary>
        /// <param name="id">The <see cref="Customer"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="Customer"/> entity</returns>
        public Customer Get(string id, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(requestOptions);
            return Client.Get<Customer>($"{BasePath}/{id}");
        }

        /// <summary>
        /// Sends a request to Globally Paid API to get a particular customer by id, as an asynchronous operation
        /// </summary>
        /// <param name="id">The <see cref="Customer"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="Customer"/> Task entity, representing the asynchronous operation</returns>
        public async Task<Customer> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(requestOptions);
            return await Client.GetAsync<Customer>($"{BasePath}/{id}", checkResponseCode: false, cancellationToken);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to create a customer
        /// </summary>
        /// <param name="customer">A <see cref="Customer"/> entity to be created</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="Customer"/> entity</returns>
        public Customer Create(Customer customer, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(customer, requestOptions);
            return Client.Post<Customer, Customer>(BasePath, customer);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to create a customer, as an asynchronous operation
        /// </summary>
        /// <param name="customer">A <see cref="Customer"/> entity to be created</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="Customer"/> Task entity, representing the asynchronous operation</returns>
        public async Task<Customer> CreateAsync(Customer customer, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(customer, requestOptions);
            return await Client.PostAsync<Customer, Customer>(BasePath, customer, checkResponseCode: false, cancellationToken);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to update a customer
        /// </summary>
        /// <param name="customer">A <see cref="Customer"/> entity to be updated</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="Customer"/> entity</returns>
        public Customer Update(Customer customer, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(customer, requestOptions, "PUT");
            return Client.Put<Customer, Customer>($"{BasePath}/{customer.Id}", customer);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to update a customer, as an asynchronous operation
        /// </summary>
        /// <param name="customer">A <see cref="Customer"/> entity to be updated</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="Customer"/> Task entity, representing the asynchronous operation</returns>
        public async Task<Customer> UpdateAsync(Customer customer, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(customer, requestOptions, "PUT");
            return await Client.PutAsync<Customer, Customer>($"{BasePath}/{customer.Id}", customer, checkResponseCode: false, cancellationToken);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to delete a customer by id
        /// </summary>
        /// <param name="id">The <see cref="Customer"/> id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        public void Delete(string id, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(string.Empty, requestOptions, "DELETE");
            Client.Delete($"{BasePath}/{id}");
        }

        /// <summary>
        /// Sends a request to Globally Paid API to delete a customer by id, as an asynchronous operation
        /// </summary>
        /// <param name="id">The <see cref="Customer"/> id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A Task entity, representing the asynchronous operation</returns>
        public async Task DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(string.Empty, requestOptions, "DELETE");
            await Client.DeleteAsync($"{BasePath}/{id}", cancellationToken);
        }
    }
}
