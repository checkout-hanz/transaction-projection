using MongoDB.Driver;

namespace Transaction.Projection.MongoDb.Configuration
{
    public interface IMongoContext
    {
        IMongoClient Client { get; }
        IMongoDatabase Database { get; }

        IMongoCollection<Transaction.Projection.MongoDb.Models.Merchant> Merchants { get; }

        IMongoCollection<Transaction.Projection.MongoDb.Models.Transaction> Transactions { get; }
    }
}