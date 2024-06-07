using Project.Models;
using Project.Models.DTO;
namespace Project.BLL
{
    public interface IManagerService
    {
        public Task<bool> CheckManager(string ManName, int Password);

    }
}
