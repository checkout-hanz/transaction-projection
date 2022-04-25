using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Projection.Messaging.Subscription
{
    public interface IMessage
    {
        public string EventName { get; set; }
    }
}
