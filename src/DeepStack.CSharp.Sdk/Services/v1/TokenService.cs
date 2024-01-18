using System.Threading;
using System.Threading.Tasks;
using DeepStack.Core;
using DeepStack.Entities.Common;
using DeepStack.Entities.Interface;
using DeepStack.Requests;
using DeepStack.Requests.Base;
using DeepStack.Services.Base;
using DeepStack.Services.v1.Interfaces;

namespace DeepStack.Services.v1
{
    /// <summary>
    /// Service to tokenize the card data
    /// </summary>
    public class TokenService : Service, ITokenService
    {
        public TokenService() { }

        public TokenService(HttpServiceClient client) : base(client) { }

        protected override string BasePath => $"api/v1/vault/token";

        /// <summary>
        /// Sends a request to Globally Paid API to tokenize particular card data
        /// </summary>
        /// <param name="request">A <see cref="TokenizeRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="PaymentInstrument"/> entity</returns>
        public IPaymentInstrument Tokenize(TokenizeRequest request, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(requestOptions);
            return Client.Post<TokenizeRequest, IPaymentInstrument>(BasePath, request);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to tokenize particular card data, as an asynchronous operation
        /// </summary>
        /// <param name="request">A <see cref="TokenizeRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="PaymentInstrument"/> Task entity, representing the asynchronous operation</returns>
        public async Task<IPaymentInstrument> TokenizeAsync(TokenizeRequest request, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(requestOptions);
            return await Client.PostAsync<TokenizeRequest, IPaymentInstrument>(BasePath, request, checkResponseCode: false, cancellationToken);
        }
    }
}
