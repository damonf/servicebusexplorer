using System.Threading.Tasks;
using System.Web.Http;
using MediatR;

namespace ServiceBusExplorer.Api.Features.Subscription
{
    [RoutePrefix("api/Subscription")]
    public class SubscriptionController : ApiController
    {
        private readonly IMediator _mediator;

        public SubscriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("{topicPath}/{name}")]
        public async Task<IHttpActionResult> Get(string topicPath, string name)
        {
            var dto = await _mediator.Send(new GetSubscription { TopicPath = topicPath, Name = name });
            return Ok(dto);
        }
    }
}
