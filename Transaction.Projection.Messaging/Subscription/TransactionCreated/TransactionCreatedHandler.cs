using AutoMapper;
using Transaction.Projection.MongoDb.Repositories;

namespace Transaction.Projection.Messaging.Subscription.TransactionCreated
{
    public class TransactionCreatedHandler : ISubscriptionHandler<TransactionCreatedEvent>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionCreatedHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task Handle(TransactionCreatedEvent message)
        {
            await _transactionRepository.InsertTransaction(_mapper.Map<MongoDb.Models.Transaction>(message));
        }
    }
}
