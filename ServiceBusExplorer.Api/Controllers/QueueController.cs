using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;

namespace ServiceBusExplorer.Api.Controllers
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
            var queueDetail = await _mediator.Send(new GetQueue { Path = path });
            return Ok(queueDetail);
        }
    }
}
