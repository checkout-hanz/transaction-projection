﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Projection.Messaging.Publisher;

namespace Transaction.Projection.Messaging.Subscription
{
    public interface ISubscriptionHandler<in T> where T : IMessage
    {
        public Task Handle(T message);
    }
}
