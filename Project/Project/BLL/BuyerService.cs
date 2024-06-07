using AutoMapper;
using Project.DAL;
using Project.Models;
using Project.Models.DTO;
namespace Project.BLL
{
    public class BuyerService:IBuyerService
    {
        private readonly IBuyerDal buyerDal;
        private readonly IMapper _mapper;

        public BuyerService(IBuyerDal buyerDal, IMapper mapper)
        {
            this.buyerDal = buyerDal;
            _mapper = mapper;
        }
        public async Task<Buyer> CheckBuyer(BuyerDTO2 buyer)
        {
            return await buyerDal.CheckBuyer(buyer);
        }
        public async Task<Buyer> RegisterBuyer(BuyerDTO buyer)
        {
            var b = _mapper.Map<Buyer>(buyer);

            return await buyerDal.RegisterBuyer(b);
        }

        public string Generate(Buyer buyer)
        {
            return buyerDal.Generate(buyer);
        }
        public Buyer Authenticate(BuyerDTO2 buyer)
        {
            return Authenticate(buyer);
        }

    }
}
