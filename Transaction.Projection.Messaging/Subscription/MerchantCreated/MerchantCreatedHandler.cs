using AutoMapper;
using Transaction.Projection.MongoDb.Models;
using Transaction.Projection.MongoDb.Repositories;

namespace Transaction.Projection.Messaging.Subscription.MerchantCreated
{
    public class MerchantCreatedHandler : ISubscriptionHandler<MerchantCreatedEvent>
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;

        public MerchantCreatedHandler(IMerchantRepository merchantRepository, IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
        }

        public async Task Handle(MerchantCreatedEvent message)
        {
            await _merchantRepository.InsertMerchant(_mapper.Map<Merchant>(message));
        }
    }
}
