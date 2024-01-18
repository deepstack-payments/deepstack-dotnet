using System.Threading;
using System.Threading.Tasks;
using DeepStack.Entities;
using DeepStack.Requests;
using DeepStack.Requests.Base;

namespace DeepStack.Services.v1.Interfaces
{
    /// <summary>
    /// Interface for charging credit or debit card
    /// </summary>
    public interface IChargeService
    {
        /// <summary>
        /// Sends a request to Globally Paid API to charge credit or debit card that is previous tokenized
        /// </summary>
        /// <param name="request">A <see cref="ChargeRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="Charge"/> entity</returns>
        ChargeResponse Charge(ChargeRequest request, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to charge credit or debit card that is previous tokenized, as an asynchronous operation
        /// </summary>
        /// <param name="request">A <see cref="ChargeRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="Charge"/> Task entity, representing the asynchronous operation</returns>
        Task<ChargeResponse> ChargeAsync(ChargeRequest request, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}