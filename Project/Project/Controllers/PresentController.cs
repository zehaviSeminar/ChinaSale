
using Project.DAL;
using Project.Models;
using Project.Models.DTO;
using Project.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresentController : ControllerBase
    {
        private readonly IPresentService _presentsService;
        public PresentController(IPresentService present)
        {
            this._presentsService = present;
        }

        [HttpGet("getAll")]       
        public async Task<IEnumerable<PresentDTO2>> Get()
        {
            return await _presentsService.Get();
        }

        [HttpGet("getPresentsPurcheses{buyerId}")]
        public async Task<IEnumerable<PresentDTO2>> getPresentsPurcheses(int buyerId)
        {
            return await _presentsService.getPresentsPurcheses(buyerId);
        }
        [HttpPost]
        [Authorize(Roles ="Manager")]
        public void AddPresents(PresentDTO p)
        {
            _presentsService.AddPresents(p);
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Manager")]
        public void RemoveById(int id)
        {
            _presentsService.RemoveById(id);
        }

  
        [HttpDelete("deleteSeveralPresents")]
        //[Authorize(Roles = "Manager")]
        public IActionResult RemoveSeveralPresent([FromBody] List<PresentDTO2> presents)
        {
            if (presents == null || presents.Count == 0)
            {
                return BadRequest("The presents list is empty or null.");
            }

            _presentsService.RemoveSeveralPresent(presents);
            return NoContent();
        }


        [HttpPut("{id}")]
        public PresentDTO UpdateP(int id, PresentDTO pre)
        {
            return _presentsService.UpdateP(id, pre);
        }

        [HttpGet("GetPresentByBuyer{IdBuyer}")]
        public Task<IEnumerable<Presents>> GetPresentByBuyer(int IdBuyer)
        {
            return _presentsService.GetPresentByBuyer(IdBuyer);
        }
        [HttpGet("getPresentByDonorId")]
     //   public IEnumerable<Presents> GetPresentByDonor(int DonorId)
    //    {
    //        return _presentsService.GetPresentByDonor(DonorId);
    //    }
        [HttpGet("getPresentByNumOfPurchasers")]
        public Task<IEnumerable<Presents>> GetPresentByNumOfPurchasers(int NumOfPurchasers)
        {
            return _presentsService.GetPresentByNumOfPurchasers(NumOfPurchasers);
        }

    }
}

