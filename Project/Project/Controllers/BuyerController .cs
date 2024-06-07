using Project.BLL;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Microsoft.AspNetCore.Authorization;
using Project.DAL;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Data;
using Project.Models.DTO;
namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class BuyerController : ControllerBase
    {
        private readonly IBuyerService _buyerService;
        private readonly Context _context;
        private readonly IConfiguration _config;

        public BuyerController(IBuyerService buyer, IConfiguration _config, Context _context)
        {
            this._buyerService = buyer;
            this._config = _config;
            this._context = _context;
        }

        [HttpGet("getUser")]
        public async Task<Buyer> CheckBuyer(BuyerDTO2 buyer)
        {
            return await _buyerService.CheckBuyer(buyer);
        }

        [HttpPost("register")]
        public Task<Buyer> RegisterBuyer(BuyerDTO buyer)
        {
            return _buyerService.RegisterBuyer(buyer);
        }


        //public string Generate(Buyer buyer)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    var claims = new[]
        //    {
        //            new Claim(ClaimTypes.NameIdentifier,buyer.Name),
        //            new Claim(ClaimTypes.Email, buyer.Email),
        //            new Claim(ClaimTypes.OtherPhone, buyer.Phone)
        //        };
        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //        _config["Jwt:Audience"],
        //        claims,
        //        expires: DateTime.Now.AddMinutes(15),
        //        signingCredentials: credentials);
        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginBuyer([FromBody] BuyerDTO2 buyer)
        {
            try
            {
                var user = await _buyerService.CheckBuyer(buyer);
                //Authenticate(buyer);
                if (user != null)
                {
                    var token = _buyerService.Generate(user);
                    return Ok(token);
                }
                return Ok("user not found");
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
