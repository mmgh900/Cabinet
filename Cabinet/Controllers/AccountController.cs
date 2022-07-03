using Cabinet.Classes;
using Cabinet.Models;
using Cabinet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cabinet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<CabinetUser> _userManager;
        private readonly IAuthManager _authManager;
        private readonly CabinetContext _db;

        public AccountController(UserManager<CabinetUser> userManager, IAuthManager authManager, CabinetContext db)
        {
            _userManager = userManager;
            _authManager = authManager;
            _db = db;
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            List<Neighborhood> neighborhoods = new List<Neighborhood>();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (userDTO.Role.ToUpper() == "ADMIN")
            {
                return BadRequest("You can't create admin user");
            }
            else if (userDTO.Role.ToUpper() == "DRIVER" && userDTO.Neighborhoods == null)
            {
                return BadRequest("You should specify your working neighborbood");
            }

            if (userDTO.Neighborhoods != null)
            {
                neighborhoods =
                await (from Neighborhood in _db.Neighborhoods
                       where userDTO.Neighborhoods.Contains(Neighborhood.Id)
                       select Neighborhood
                   ).ToListAsync();
            }


            var cabinetUser = new CabinetUser
            {
                UserName = userDTO.Email,
                PhoneNumber = userDTO.PhoneNumber,
                Email = userDTO.Email,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                WorkingNeighborhoods = neighborhoods
            };


            var result = await _userManager.CreateAsync(cabinetUser, userDTO.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }
            await _userManager.AddToRoleAsync(cabinetUser, userDTO.Role);
            if (!await _authManager.ValidateUser(userDTO))
            {
                return Unauthorized();
            }


            var response = new { Token = await _authManager.CreateToken() };
            return Accepted(response);

        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (!await _authManager.ValidateUser(user))
            {
                return Unauthorized();
            }


            var response = new { Token = await _authManager.CreateToken() };
            return Accepted(response);


        }
    }
}
