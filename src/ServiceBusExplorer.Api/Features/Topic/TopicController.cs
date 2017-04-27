using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MediatR;
using ServiceBusExplorer.Api.Models;

namespace ServiceBusExplorer.Api.Features.Topic
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
        [ResponseType(typeof(TopicDetailModel))]
        public async Task<IHttpActionResult> Get(string path)
        {
            var dto = await _mediator.Send(new GetTopic { Path = path });
            return Ok(dto);
        }
    }
}
