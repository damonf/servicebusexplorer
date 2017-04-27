using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MediatR;
using ServiceBusExplorer.Api.Models;

namespace ServiceBusExplorer.Api.Features.ServiceBus
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
        [ResponseType(typeof(ServiceBusModel))]
        public async Task<IHttpActionResult> Get()
        {
            var serviceBusDescription = await _mediator.Send(new GetServiceBus());
            return Ok(serviceBusDescription);
        }

        [Route("Name")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> GetAddress()
        {
            var address = await _mediator.Send(new GetServiceBusAddress());
            return Ok(address.Host);
        }
    }
}
