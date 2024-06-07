using Project.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            this._managerService = managerService;
        }

        [HttpGet("get")]
        public Task<bool> CheckManagerGet(string ManName, int Password)
        {
            return _managerService.CheckManager(ManName,Password);
        }
    }
}
