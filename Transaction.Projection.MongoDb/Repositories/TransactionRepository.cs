using Transaction.Projection.MongoDb.Configuration;
using MongoDB.Driver;

namespace Transaction.Projection.MongoDb.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IMongoContext _mongoContext;

    public TransactionRepository(IMongoContext mongoContext)
    {
        _mongoContext = mongoContext;
    }

    public async Task InsertTransaction(Models.Transaction transaction)
    {
        await _mongoContext.Transactions.InsertOneAsync(transaction);
    }

    public async Task<IEnumerable<Models.Transaction>> GetMerchantTransactions(Guid merchantId)
    {
        return await _mongoContext.Transactions.Find(x => x.MerchantId == merchantId).ToListAsync();
    }
}