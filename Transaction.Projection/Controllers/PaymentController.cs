using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Transaction.Projection.MongoDb.Repositories;

namespace Transaction.Projection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IMerchantRepository _merchantRepository;

        public PaymentController(ITransactionRepository transactionRepository, IMerchantRepository merchantRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _merchantRepository = merchantRepository;
        }

        [HttpGet("{merchantId}")]
        [ProducesResponseType(typeof(IEnumerable<Models.Transaction>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Models.Transaction>))]
        public async Task<IActionResult> Get(Guid merchantId)
        {
            var merchant = await _merchantRepository.GetMerchant(merchantId);
            if (merchant == null)
            {
                return NotFound();
            }

            var transactions =  await _transactionRepository.GetMerchantTransactions(merchantId);
            return Ok(_mapper.Map<IEnumerable<Models.Transaction>>(transactions));
        }
    }
}