using Project.Models;
using Project.Models.DTO;

namespace Project.DAL
{
    public interface IPresentDal
    {
        public Task<IEnumerable<Presents>> Get();
        public Presents AddPresents(Presents p);
        public void RemoveById(int id);
        public Presents UpdateP(int id, Presents pre);
        public Task<IEnumerable<Presents>> GetPresentByBuyer(int IdBuyer);
        public Task<List<Presents>> GetPresentByDonor(int DonorId);
        public Task<IEnumerable<Presents>> GetPresentByNumOfPurchasers(int NumOfPurchasers);
        public Task<IEnumerable<Presents>> getPresentsPurcheses(int buyerId);
        public void RemoveSeveralPresent(List<PresentDTO2> presents);


    }
}
