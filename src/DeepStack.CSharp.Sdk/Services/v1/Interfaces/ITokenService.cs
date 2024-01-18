using System.Threading;
using System.Threading.Tasks;
using DeepStack.Entities.Common;
using DeepStack.Entities.Interface;
using DeepStack.Requests;
using DeepStack.Requests.Base;

namespace DeepStack.Services.v1.Interfaces
{
    /// <summary>
    /// Interface to tokenize the card data
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Sends a request to Globally Paid API to tokenize particular card data
        /// </summary>
        /// <param name="request">A <see cref="TokenizeRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="PaymentInstrument"/> entity</returns>
        IPaymentInstrument Tokenize(TokenizeRequest request, RequestOptions requestOptions = null);

        /// <summary>
        /// Sends a request to Globally Paid API to tokenize particular card data, as an asynchronous operation
        /// </summary>
        /// <param name="request">A <see cref="TokenizeRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="PaymentInstrument"/> Task entity, representing the asynchronous operation</returns>
        Task<IPaymentInstrument> TokenizeAsync(TokenizeRequest request, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}
