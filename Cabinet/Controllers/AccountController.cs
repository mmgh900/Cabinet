using Cabinet.Classes;
using Cabinet.Models;
using Cabinet.Services;
using Microsoft.AspNet.Identity.EntityFramework;
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



        [HttpGet("{email}/profile")]
        public async Task<IActionResult> GetUserProfile(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var role = (await _userManager.GetRolesAsync(user))[0];
            var u = await _db.Users.Where(u => u.Email == email || u.UserName == email).Select(u => new UserViewDTO
            {
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Neighborhoods = u.WorkingNeighborhoods.Select(n => n.Name).ToList(),
                NumberOfCommutes = role == "Commuter" ? u.CommuterCommutes.Count() : u.DriverCommutes.Count(),
                PhoneNumber = u.PhoneNumber,
                Role = role,
                Score = role == "Commuter" ? u.CommuterCommutes.Select(c => c.Score).Average() : u.DriverCommutes.Select(c => c.Score).Average(),
                IsBlocked = u.IsBlocked

            }).FirstOrDefaultAsync();

            if (u == null)
            {
                return NotFound();
            }
            return Ok(u);
        }



        [HttpGet("users")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsers()
        {

            return Ok(await _db.Users.Select(u => new
            {
                u.Email,
                FullName = u.FirstName + " " + u.LastName,
            }).ToListAsync());
        }


        [HttpPatch("{email}/block")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ToggleBlock(string email)
        {
            var user = _db.Users.Where(u => u.Email == email).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            user.IsBlocked = !user.IsBlocked;
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
