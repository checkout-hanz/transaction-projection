using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Projection.Messaging.Publisher
{
    internal class GenericEvent : IEvent
    {
        public string EventName { get; set; }
    }
}
