namespace Transaction.Projection.MongoDb.Repositories
{
    public interface ITransactionRepository
    {
        Task InsertTransaction(Models.Transaction transaction);
        Task<IEnumerable<MongoDb.Models.Transaction>> GetMerchantTransactions(Guid merchantId);
    }
}

