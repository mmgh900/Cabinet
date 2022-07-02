using Cabinet.Classes;

namespace Cabinet.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDTO loginDTO);
        Task<string> CreateToken(); 
        
    }
}
