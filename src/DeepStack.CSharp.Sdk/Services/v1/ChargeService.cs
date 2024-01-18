using System.Threading;
using System.Threading.Tasks;
using DeepStack.Core;
using DeepStack.Entities;
using DeepStack.Requests;
using DeepStack.Requests.Base;
using DeepStack.Services.Base;
using DeepStack.Services.v1.Interfaces;

namespace DeepStack.Services.v1
{
    /// <summary>
    /// Service for charging credit or debit card
    /// </summary>
    public class ChargeService : Service, IChargeService
    {
        protected override string BasePath => $"api/v1/payments/charge";
        private readonly TokenService tokenService;

        public ChargeService()
        {
            if(tokenService == null)
            {
                tokenService = new TokenService();
            }
        }

        public ChargeService(HttpServiceClient client) : base(client) 
        {
            if (tokenService == null)
            {
                tokenService = new TokenService(client);
            }
        }

        /// <summary>
        /// Sends a request to Globally Paid API to charge credit or debit card that was previously tokenized
        /// </summary>
        /// <param name="request">A <see cref="ChargeRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="Charge"/> entity</returns>
        public ChargeResponse Charge(ChargeRequest request, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(request, requestOptions);
            return Client.Post<ChargeRequest, ChargeResponse>(BasePath, request, checkResponseCode: true);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to charge credit or debit card that was previously tokenized, as an asynchronous operation
        /// </summary>
        /// <param name="request">A <see cref="ChargeRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="Charge"/> Task entity, representing the asynchronous operation</returns>
        public async Task<ChargeResponse> ChargeAsync(ChargeRequest request, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(request, requestOptions);
            return await Client.PostAsync<ChargeRequest, ChargeResponse>(BasePath, request, checkResponseCode: true, cancellationToken);
        }

    }
}