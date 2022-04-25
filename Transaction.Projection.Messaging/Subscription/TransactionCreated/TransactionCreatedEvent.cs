using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Projection.Messaging.Publisher;
using Transaction.Projection.MongoDb.Models;

namespace Transaction.Projection.Messaging.Subscription.TransactionCreated
{
    public class TransactionCreatedEvent : IMessage
    {
        public TransactionCreatedEvent()
        {
            EventName = nameof(TransactionCreatedEvent);
        }

        public string EventName { get; set; }
        public Guid TransactionId { get; set; }
        public Guid MerchantId { get; set; }
        public decimal Amount { get; set; }
        public string CardNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public string Currency { get; set; }
        public string CVV { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public PaymentTransactionStatus Status { get; set; }
    }
}
