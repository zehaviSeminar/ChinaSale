using AutoMapper;
using Project.DAL;
using Project.Models;
using Project.Models.DTO;

namespace Project.BLL;

public class ManagerService:IManagerService
{
    private readonly IManagerDal managerDal;
    private readonly IMapper _mapper;


    public ManagerService(IManagerDal managerDal, IMapper mapper)
    {
        this.managerDal = managerDal;
        _mapper = mapper;
    }
    public async Task<bool> CheckManager(string ManName, int Password)
    {
        var b = await managerDal.CheckManager(ManName, Password);
        return b;
    }



}

