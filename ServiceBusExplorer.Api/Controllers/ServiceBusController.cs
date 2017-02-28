using System.Threading.Tasks;
using System.Web.Http;
using MediatR;

namespace ServiceBusExplorer.Api.Controllers
{
    [RoutePrefix("api/ServiceBus")]
    public class ServiceBusController : ApiController
    {
        private readonly IMediator _mediator;

        public ServiceBusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route]
        public async Task<IHttpActionResult> Get()
        {
            var serviceBusDescription = await _mediator.Send(new GetServiceBus());
            return Ok(serviceBusDescription);
        }

        [Route("Name")]
        public async Task<IHttpActionResult> GetAddress()
        {
            var address = await _mediator.Send(new GetServiceBusAddress());
            return Ok(address.Host);
        }
    }
}
