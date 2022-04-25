using AutoMapper;
using Transaction.Projection.Messaging.Subscription.TransactionCreated;

namespace Transaction.Projection.Mappers
{
    public class TransactionProjectionMapperProfile : Profile
    {
        public TransactionProjectionMapperProfile()
        {
            CreateMap<MongoDb.Models.Transaction, Models.Transaction>();

            CreateMap<Messaging.Subscription.MerchantCreated.MerchantCreatedEvent, MongoDb.Models.Merchant>();
            CreateMap<TransactionCreatedEvent, MongoDb.Models.Transaction>();
        }
    }
}
