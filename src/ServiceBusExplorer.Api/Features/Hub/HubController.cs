using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ServiceBusExplorer.Api.Features.Hub
{
    /// <summary>
    /// Control the signalR hub.
    /// </summary>
    [RoutePrefix("api/Hub")]
    public class HubController : ApiController
    {
        private readonly IHubTicker _hubTicker;

        public HubController(IHubTicker hubTicker)
        {
            _hubTicker = hubTicker;
        }

        /// <summary>
        /// Start the signalR hub.
        /// </summary>
        /// <remarks>
        /// Starts the signalR hub for automatic updates.
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpPost]
        [Route("Start")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Start()
        {
            await _hubTicker.StartAsync();

            return Ok();
        }

        /// <summary>
        /// Stop the signalR hub.
        /// </summary>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpPost]
        [Route("Stop")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Stop()
        {
            await _hubTicker.StopAsync();

            return Ok();
        }
    }
}
