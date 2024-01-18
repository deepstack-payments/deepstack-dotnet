using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DeepStack.Entities;
using DeepStack.Requests.Base;

namespace DeepStack.Services.v1.Interfaces
{
    /// <summary>
    /// Interface for Create, Read, Update and Delete of the <see cref="Customer"/> entity
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Sends a request to Globally Paid API to get all customers
        /// </summary>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A list of <see cref="Customer"/> entities</returns>
        List<Customer> List(RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to get all customers, as an asynchronous operation
        /// </summary>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A list of <see cref="Customer"/> Task entities, representing the asynchronous operation</returns>
        Task<List<Customer>> ListAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a request to Globally Paid API to get a particular customer by id
        /// </summary>
        /// <param name="id">The <see cref="Customer"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="Customer"/> entity</returns>
        Customer Get(string id, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to get a particular customer by id, as an asynchronous operation
        /// </summary>
        /// <param name="id">The <see cref="Customer"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="Customer"/> Task entity, representing the asynchronous operation</returns>
        Task<Customer> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a request to Globally Paid API to create a customer
        /// </summary>
        /// <param name="customer">A <see cref="Customer"/> entity to be created</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="Customer"/> entity</returns>
        Customer Create(Customer customer, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to create a customer, as an asynchronous operation
        /// </summary>
        /// <param name="customer">A <see cref="Customer"/> entity to be created</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="Customer"/> Task entity, representing the asynchronous operation</returns>
        Task<Customer> CreateAsync(Customer customer, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a request to Globally Paid API to update a customer
        /// </summary>
        /// <param name="customer">A <see cref="Customer"/> entity to be updated</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="Customer"/> entity</returns>
        Customer Update(Customer customer, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to update a customer, as an asynchronous operation
        /// </summary>
        /// <param name="customer">A <see cref="Customer"/> entity to be updated</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="Customer"/> Task entity, representing the asynchronous operation</returns>
        Task<Customer> UpdateAsync(Customer customer, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a request to Globally Paid API to delete a customer by id
        /// </summary>
        /// <param name="id">The <see cref="Customer"/> id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        void Delete(string id, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to delete a customer by id, as an asynchronous operation
        /// </summary>
        /// <param name="id">The <see cref="Customer"/> id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A Task entity, representing the asynchronous operation</returns>
        Task DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}
