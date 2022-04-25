﻿using MongoDB.Bson.Serialization.Attributes;
using Transaction.Projection.MongoDb.Models;

namespace Transaction.Projection.Models
{
    public class Transaction
    {
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
