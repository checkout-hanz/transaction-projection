using MongoDB.Driver;

namespace Transaction.Projection.MongoDb.Configuration
{
    public class MongoContext : IMongoContext
    {
        private readonly Lazy<IMongoDatabase> _database;

        private readonly Lazy<IMongoCollection<Transaction.Projection.MongoDb.Models.Merchant>> _messageRecords;

        private readonly Lazy<IMongoCollection<Transaction.Projection.MongoDb.Models.Transaction>> _transactions;

        public MongoContext(IMongoClient mongoClient, IMongoSettings mongoSettings)
        {
            Client = mongoClient;
            _database = new Lazy<IMongoDatabase>(() => mongoClient.GetDatabase(mongoSettings.Database));

            Lazy<IMongoCollection<T>> CreateLazyCollection<T>(string collectionName)
            {
                return new Lazy<IMongoCollection<T>>(() => Database.GetCollection<T>(collectionName));
            }

            _messageRecords = CreateLazyCollection<Transaction.Projection.MongoDb.Models.Merchant>(DatabaseConstants.MerchantCollection);

            _transactions = CreateLazyCollection<Transaction.Projection.MongoDb.Models.Transaction>(DatabaseConstants.TransactionCollection);
        }

        public IMongoClient Client { get; }
        public IMongoDatabase Database => _database.Value;
        public IMongoCollection<Transaction.Projection.MongoDb.Models.Merchant> Merchants => _messageRecords.Value;

        public IMongoCollection<Transaction.Projection.MongoDb.Models.Transaction> Transactions => _transactions.Value;
    }
}
