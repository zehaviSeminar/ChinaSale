using Project.Models;

namespace Project.DAL
{
    public interface IManagerDal
    {
        public Task<bool> CheckManager(string ManName, int Password);

    }
}
