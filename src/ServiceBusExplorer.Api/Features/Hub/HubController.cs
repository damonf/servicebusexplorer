using System.Threading.Tasks;
using System.Web.Http;

namespace ServiceBusExplorer.Api.Features.Hub
{
    [RoutePrefix("api/Hub")]
    public class HubController : ApiController
    {
        private readonly IHubTicker _hubTicker;

        public HubController(IHubTicker hubTicker)
        {
            _hubTicker = hubTicker;
        }

        [HttpPost]
        [Route("Start")]
        public async Task<IHttpActionResult> Start()
        {
            await _hubTicker.StartAsync();

            return Ok();
        }

        [HttpPost]
        [Route("Stop")]
        public async Task<IHttpActionResult> Stop()
        {
            await _hubTicker.StopAsync();

            return Ok();
        }
    }
}
