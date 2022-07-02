using Cabinet.Classes;
using Cabinet.Models;
using Cabinet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cabinet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<CabinetUser> _userManager;
        private readonly IAuthManager _authManager;

        public AccountController(UserManager<CabinetUser> userManager, IAuthManager authManager)
        {
            _userManager = userManager;
            _authManager = authManager;
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var cabinetUser = new CabinetUser
                {
                    UserName = userDTO.Email,
                    PhoneNumber = userDTO.PhoneNumber,
                    Email = userDTO.Email,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,

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

                return Accepted();
            }
            catch
            {
                return Problem();
            }
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
