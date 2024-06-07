using Project.Models;
namespace Project.DAL
{
    public interface IDonorsDal
    {
        public Task<IEnumerable<Donors>> Get();
        public Task<Donors> AddDonors(Donors d);
        public void RemoveById(int id);
        public Task<Donors> UpdateD(int id, Donors don);
        public Task<IEnumerable<Donors>> GetDonorByName(string nameD);
        public Task<IEnumerable<Donors>> GetDonorByEmail(string Email);
        public Task<Donors> GetDonorByPresent(int IdPresent);



    }
}
