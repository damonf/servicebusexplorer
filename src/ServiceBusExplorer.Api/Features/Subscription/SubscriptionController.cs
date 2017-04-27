using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MediatR;
using ServiceBusExplorer.Api.Models;

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
        [ResponseType(typeof(SubscriptionDetailModel))]
        public async Task<IHttpActionResult> Get(string topicPath, string name)
        {
            var dto = await _mediator.Send(new GetSubscription { TopicPath = topicPath, Name = name });
            return Ok(dto);
        }
    }
}
