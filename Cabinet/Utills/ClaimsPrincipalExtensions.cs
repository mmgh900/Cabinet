using System.Security.Claims;

namespace Cabinet.Utills
{

    public static class ClaimsPrincipalExtensions
    {
        //https://stackoverflow.com/questions/30701006/how-to-get-the-current-logged-in-user-id-in-asp-net-core
        //https://stackoverflow.com/questions/11938044/what-are-the-best-practices-for-using-a-guid-as-a-primary-key-specifically-rega




        public static string? GetUserName(this ClaimsPrincipal principal)
        {
            return !principal.Claims.Any() ? null : principal.FindFirstValue(ClaimTypes.Name);
        }



    }
}
