using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DeepStack.Entities;
using DeepStack.Entities.Common;
using DeepStack.Entities.Interface;
using DeepStack.Requests;
using DeepStack.Requests.Base;

namespace DeepStack.Services.v1.Interfaces
{
    /// <summary>
    /// Interface for Create, Read, Update and Delete of the <see cref="PaymentInstrument"/> entity
    /// </summary>
    public interface IPaymentInstrumentService
    {
        /// <summary>
        /// Sends a request to Globally Paid API to get all payment instruments
        /// </summary>
        /// <param name="customerId">The <see cref="Customer"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A list of <see cref="PaymentInstrument"/> entities</returns>
        List<IPaymentInstrument> List(string customerId, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to get all payment instruments, as an asynchronous operation
        /// </summary>
        /// <param name="customerId">The <see cref="Customer"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A list of <see cref="PaymentInstrument"/> Task entities, representing the asynchronous operation</returns>
        Task<List<IPaymentInstrument>> ListAsync(string customerId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a request to Globally Paid API to get a particular payment instrument by id
        /// </summary>
        /// <param name="id">The <see cref="PaymentInstrument"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="PaymentInstrument"/> entity</returns>
        IPaymentInstrument Get(string id, string customerId, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to get a particular payment instrument by id, as an asynchronous operation
        /// </summary>
        /// <param name="id">The <see cref="PaymentInstrument"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="PaymentInstrument"/> Task entity, representing the asynchronous operation</returns>
        Task<IPaymentInstrument> GetAsync(string id, string customerId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a request to Globally Paid API to create a payment instrument
        /// </summary>
        /// <param name="creditCardNumber">The credit card number</param>
        /// <param name="creditCardCvv">The credit card CVV</param>
        /// <param name="paymentInstrument">A <see cref="PaymentInstrument"/> entity to be created</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="PaymentInstrument"/> entity</returns>
        IPaymentInstrument Create(PaymentInstrumentRequest paymentInstrumentRequest, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to create a payment instrument, as an asynchronous operation
        /// </summary>
        /// <param name="creditCardNumber">The credit card number</param>
        /// <param name="creditCardCvv">The credit card CVV</param>
        /// <param name="paymentInstrument">A <see cref="PaymentInstrument"/> entity to be created</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="PaymentInstrument"/> Task entity, representing the asynchronous operation</returns>
        Task<IPaymentInstrument> CreateAsync(IPaymentInstrument paymentInstrument, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a request to Globally Paid API to create a payment instrument from a token
        /// </summary>
        /// <param name="paymentInstrumentTokenRequest"></param>
        /// <param name="requestOptions"></param>
        /// <returns></returns>
        IPaymentInstrument Create(PaymentInstrumentTokenRequest paymentInstrumentTokenRequest, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to create a payment instrument from a token, as an asynchronous operation
        /// </summary>
        /// <param name="paymentInstrumentTokenRequest"></param>
        /// <param name="requestOptions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IPaymentInstrument> CreateAsync(PaymentInstrumentTokenRequest paymentInstrumentTokenRequest,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a request to Globally Paid API to updated a payment instrument
        /// </summary>
        /// <param name="paymentInstrument">A <see cref="PaymentInstrument"/> entity to be updated</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="PaymentInstrument"/> entity</returns>
        IPaymentInstrument Update(IPaymentInstrument paymentInstrument, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to updated a payment instrument, as an asynchronous operation
        /// </summary>
        /// <param name="paymentInstrument">A <see cref="PaymentInstrument"/> entity to be updated</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="PaymentInstrument"/> Task entity, representing the asynchronous operation</returns>
        Task<IPaymentInstrument> UpdateAsync(IPaymentInstrument paymentInstrument, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a request to Globally Paid API to delete a payment instrument by id
        /// </summary>
        /// <param name="id">The <see cref="PaymentInstrument"/> id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        bool Delete(string id, string customerId = "deprecated", RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to delete a payment instrument by id, as an asynchronous operation
        /// </summary>
        /// <param name="id">The <see cref="PaymentInstrument"/> id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A Task entity, representing the asynchronous operation</returns>
        Task DeleteAsync(string id, string customerId = "deprecated", RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}
