using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MediatR;
using ServiceBusExplorer.Api.Models;

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
        [ResponseType(typeof(QueueDetailModel))]
        public async Task<IHttpActionResult> Get(string path)
        {
            var dto = await _mediator.Send(new GetQueue { Path = path });
            return Ok(dto);
        }
    }
}
