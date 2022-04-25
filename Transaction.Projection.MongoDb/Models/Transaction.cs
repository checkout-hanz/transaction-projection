using MongoDB.Bson.Serialization.Attributes;

namespace Transaction.Projection.MongoDb.Models
{
    public class Transaction
    {
        [BsonId]
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