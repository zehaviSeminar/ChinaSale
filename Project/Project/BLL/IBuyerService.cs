using AutoMapper;
using Project.DAL;
using Project.Models.DTO;
using Project.Models;

namespace Project.BLL
{
    public interface IBuyerService
    { 
        public Task<Buyer> CheckBuyer(BuyerDTO2 buyer);
        public Task<Buyer> RegisterBuyer(BuyerDTO buyer);

        public string Generate(Buyer buyer);
        public Buyer Authenticate(BuyerDTO2 buyer);
    }
}
