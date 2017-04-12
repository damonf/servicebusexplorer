using System.Threading.Tasks;
using System.Web.Http;
using MediatR;

namespace ServiceBusExplorer.Api.Features.Queue
{
    [RoutePrefix("api/Queue")]
    public class QueueController : ApiController
    {
        private readonly IMediator _mediator;

        public QueueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("{path}")]
        public async Task<IHttpActionResult> Get(string path)
        {
            var dto = await _mediator.Send(new GetQueue { Path = path });
            return Ok(dto);
        }
    }
}
