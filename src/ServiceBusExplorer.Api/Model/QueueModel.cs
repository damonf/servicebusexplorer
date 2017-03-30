using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusExplorer.Api.Model
{
    public class QueueModel
    {
        public string Name { get; set; }
        public long ActiveMessageCount { get; set; }
        public long DeadLetterMessageCount { get; set; }
    }
}
