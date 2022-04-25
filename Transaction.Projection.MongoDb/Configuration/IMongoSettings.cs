namespace Transaction.Projection.MongoDb.Configuration
{
    public interface IMongoSettings
    {
        string ConnectionString { get; }
        string Database { get; }
    }
}
