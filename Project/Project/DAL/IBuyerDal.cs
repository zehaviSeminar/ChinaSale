using Project.Models;
using Project.Models.DTO;

namespace Project.DAL
{
    public interface IBuyerDal
    {
        public Task<Buyer> CheckBuyer(BuyerDTO2 buyer);
        public Task<Buyer> RegisterBuyer(Buyer buyer);
        //login
        public string Generate(Buyer buyer);
        public Buyer Authenticate(BuyerDTO2 buyer);

    }
}
