using Cabinet.Classes;
using Cabinet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cabinet.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<CabinetUser> _userManager;
        private readonly IConfiguration _configuration;
        private CabinetUser? _user;

        public AuthManager(UserManager<CabinetUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _user = null;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSiginingCredentials();
            var claims = await GetClaims();
            var token = GetTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GetTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            return new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JwtSettings:Issuer"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCredentials
            );
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }


        private SigningCredentials GetSiginingCredentials()
        {
            var key = _configuration["JwtSettings:SecretKey"];
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            return signingCredentials;

        }

        public async Task<bool> ValidateUser(LoginDTO loginDTO)
        {
            _user = await _userManager.FindByEmailAsync(loginDTO.Email);
            return (_user != null && await _userManager.CheckPasswordAsync(_user, loginDTO.Password));
        }
    }
}
