using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DeepStack.Core;
using DeepStack.Entities;
using DeepStack.Entities.Interface;
using DeepStack.Requests;
using DeepStack.Requests.Base;
using DeepStack.Services.Base;
using DeepStack.Services.v1.Interfaces;

namespace DeepStack.Services.v1
{
    /// <summary>
    /// Service for Create, Read, Update and Delete of the <see cref="IPaymentInstrument"/> entity
    /// </summary>
    public class PaymentInstrumentService : Service, IPaymentInstrumentService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PaymentInstrumentService() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client"></param>
        public PaymentInstrumentService(HttpServiceClient client) : base(client) { }

        /// <summary>
        /// BasePath
        /// </summary>
        protected override string BasePath => $"/api/v1/vault/payment-instrument";

        /// <summary>
        /// Sends a request to Globally Paid API to get all payment instruments
        /// </summary>
        /// <param name="customerId">The <see cref="Customer"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A list of <see cref="IPaymentInstrument"/> entities</returns>
        public List<IPaymentInstrument> List(string customerId, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(requestOptions);
            return Client.Get<List<IPaymentInstrument>>($"{BasePath}/list/{customerId}");
        }

        /// <summary>
        /// Sends a request to Globally Paid API to get all payment instruments, as an asynchronous operation
        /// </summary>
        /// <param name="customerId">The <see cref="Customer"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A list of <see cref="IPaymentInstrument"/> Task entities, representing the asynchronous operation</returns>
        public async Task<List<IPaymentInstrument>> ListAsync(string customerId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(requestOptions);
            return await Client.GetAsync<List<IPaymentInstrument>>($"{BasePath}/list/{customerId}", checkResponseCode: false, cancellationToken);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to get a particular payment instrument by id
        /// </summary>
        /// <param name="id">The <see cref="IPaymentInstrument"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="IPaymentInstrument"/> entity</returns>
        public IPaymentInstrument Get(string id, string customerId, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(requestOptions);
            return Client.Get<IPaymentInstrument>($"{BasePath}/{customerId}/{id}");
        }

        /// <summary>
        /// Sends a request to Globally Paid API to get a particular payment instrument by id, as an asynchronous operation
        /// </summary>
        /// <param name="id">The <see cref="IPaymentInstrument"/> Id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="IPaymentInstrument"/> Task entity, representing the asynchronous operation</returns>
        public async Task<IPaymentInstrument> GetAsync(string id, string customerId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(requestOptions);
            return await Client.GetAsync<IPaymentInstrument>($"{BasePath}/{customerId}/{id}", checkResponseCode: false, cancellationToken);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to create a payment instrument
        /// </summary>
        /// <param name="creditCardNumber">The credit card number</param>
        /// <param name="creditCardCvv">The credit card CVV</param>
        /// <param name="IPaymentInstrument">A <see cref="IPaymentInstrument"/> entity to be created</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="IPaymentInstrument"/> entity</returns>
        public IPaymentInstrument Create(PaymentInstrumentRequest paymentInstrumentRequest, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(paymentInstrumentRequest, requestOptions);
            return Client.Post<PaymentInstrumentRequest, IPaymentInstrument>($"{BasePath}/{paymentInstrumentRequest.CustomerId}", paymentInstrumentRequest);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to create a payment instrument, as an asynchronous operation
        /// </summary>
        /// <param name="creditCardNumber">The credit card number</param>
        /// <param name="creditCardCvv">The credit card CVV</param>
        /// <param name="IPaymentInstrument">A <see cref="IPaymentInstrument"/> entity to be created</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="IPaymentInstrument"/> Task entity, representing the asynchronous operation</returns>
        public async Task<IPaymentInstrument> CreateAsync(IPaymentInstrument paymentInstrument, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(paymentInstrument, requestOptions);
            return await Client.PostAsync<IPaymentInstrument, IPaymentInstrument>($"{BasePath}/{paymentInstrument.CustomerId}", paymentInstrument, checkResponseCode: false, cancellationToken);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to create a payment instrument from a token
        /// </summary>
        /// <param name="paymentInstrumentTokenRequest"></param>
        /// <param name="requestOptions"></param>
        /// <returns></returns>
        public IPaymentInstrument Create(PaymentInstrumentTokenRequest paymentInstrumentTokenRequest,
            RequestOptions requestOptions = null)
        {
            TryReconfigureClient(paymentInstrumentTokenRequest, requestOptions, "POST");
            return Client.Post<PaymentInstrumentTokenRequest, IPaymentInstrument>($"{BasePath}/token",
                paymentInstrumentTokenRequest);
        }
        
        /// <summary>
        /// Sends a request to Globally Paid API to create a payment instrument from a token, as an asynchronous operation
        /// </summary>
        /// <param name="paymentInstrumentTokenRequest"></param>
        /// <param name="requestOptions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IPaymentInstrument> CreateAsync(PaymentInstrumentTokenRequest paymentInstrumentTokenRequest,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(paymentInstrumentTokenRequest, requestOptions, "POST");
            return await Client.PostAsync<PaymentInstrumentTokenRequest, IPaymentInstrument>($"{BasePath}/token",
                paymentInstrumentTokenRequest, checkResponseCode: false, cancellationToken);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to updated a payment instrument
        /// </summary>
        /// <param name="IPaymentInstrument">A <see cref="IPaymentInstrument"/> entity to be updated</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="IPaymentInstrument"/> entity</returns>
        public IPaymentInstrument Update(IPaymentInstrument paymentInstrument, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(paymentInstrument, requestOptions, "PUT");
            return Client.Put<IPaymentInstrument, IPaymentInstrument>($"{BasePath}/{paymentInstrument.CustomerId}/{paymentInstrument.Id}", paymentInstrument);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to updated a payment instrument, as an asynchronous operation
        /// </summary>
        /// <param name="IPaymentInstrument">A <see cref="IPaymentInstrument"/> entity to be updated</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="IPaymentInstrument"/> Task entity, representing the asynchronous operation</returns>
        public async Task<IPaymentInstrument> UpdateAsync(IPaymentInstrument paymentInstrument, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(paymentInstrument, requestOptions, "PUT");
            return await Client.PutAsync<IPaymentInstrument, IPaymentInstrument>($"{BasePath}/{paymentInstrument.CustomerId}/{paymentInstrument.Id}", paymentInstrument, checkResponseCode: false, cancellationToken);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to delete a payment instrument by id
        /// </summary>
        /// <param name="id">The <see cref="IPaymentInstrument"/> id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        public bool Delete(string id, string customerId = "deprecated", RequestOptions requestOptions = null)
        {
            TryReconfigureClient(string.Empty, requestOptions, "DELETE");
            return Client.Delete($"{BasePath}/{customerId}/{id}");
        }

        /// <summary>
        /// Sends a request to Globally Paid API to delete a payment instrument by id, as an asynchronous operation
        /// </summary>
        /// <param name="id">The <see cref="IPaymentInstrument"/> id</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A Task entity, representing the asynchronous operation</returns>
        public async Task DeleteAsync(string id, string customerId = "deprecated", RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(string.Empty, requestOptions, "DELETE");
            await Client.DeleteAsync($"{BasePath}/{customerId}/{id}", cancellationToken);
        }
    }
}
