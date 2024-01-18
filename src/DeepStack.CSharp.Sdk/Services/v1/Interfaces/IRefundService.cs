using System.Threading;
using System.Threading.Tasks;
using DeepStack.Entities;
using DeepStack.Requests;
using DeepStack.Requests.Base;

namespace DeepStack.Services.v1.Interfaces
{
    /// <summary>
    /// Interface for refunding charges
    /// </summary>
    public interface IRefundService
    {
        /// <summary>
        /// Sends a request to Globally Paid API to refund a particular charge
        /// </summary>
        /// <param name="request">A <see cref="RefundRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="Refund"/> entity</returns>
        Refund Refund(RefundRequest request, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to refund a particular charge, as an asynchronous operation
        /// </summary>
        /// <param name="request">A <see cref="RefundRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="Refund"/> Task entity, representing the asynchronous operation</returns>
        Task<Refund> RefundAsync(RefundRequest request, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}
