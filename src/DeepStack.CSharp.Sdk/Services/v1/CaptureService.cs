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
    /// Service for capturing charges
    /// </summary>
    public class CaptureService : Service, ICaptureService
    {
        public CaptureService() { }

        public CaptureService(HttpServiceClient client) : base(client) { }

        protected override string BasePath => $"api/v1/payments/capture";

        /// <summary>
        /// Sends a request to Globally Paid API to capture a particular charge
        /// </summary>
        /// <param name="request">A <see cref="CaptureRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <returns>A <see cref="Capture"/> entity</returns>
        public Capture Capture(CaptureRequest request, RequestOptions requestOptions = null)
        {
            TryReconfigureClient(request, requestOptions);
            return Client.Post<CaptureRequest, Capture>(BasePath, request, checkResponseCode: true);
        }

        /// <summary>
        /// Sends a request to Globally Paid API to capture a particular charge, as an asynchronous operation
        /// </summary>
        /// <param name="request">A <see cref="CaptureRequest"/> request object</param>
        /// <param name="requestOptions">Used to reconfigure Globally Paid SDK setting for this particular call</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation</param>
        /// <returns>A <see cref="Capture"/> Task entity, representing the asynchronous operation</returns>
        public async Task<Capture> CaptureAsync(CaptureRequest request, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            TryReconfigureClient(request, requestOptions);
            return await Client.PostAsync<CaptureRequest, Capture>(BasePath, request, checkResponseCode: true, cancellationToken);
        }
    }
}