using System.Threading.Tasks;
using System.Web.Http;
using MediatR;

namespace ServiceBusExplorer.Api.Controllers
{
    [RoutePrefix("api/Topic")]
    public class TopicController : ApiController
    {
        private readonly IMediator _mediator;

        public TopicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("{path}")]
        public async Task<IHttpActionResult> Get(string path)
        {
            var dto = await _mediator.Send(new GetTopic { Path = path });
            return Ok(dto);
        }
    }
}
