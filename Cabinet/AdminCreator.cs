using Cabinet.Models;
using Microsoft.AspNetCore.Identity;

internal class AdminCreator
{
    internal static async Task CreateAdmin(IServiceProvider serviceProvider)
    {
        var UserManager = serviceProvider.GetRequiredService<UserManager<CabinetUser>>();
        if ((await UserManager.FindByNameAsync("admin@cabinet.com")) == null)
        {
            var admin = new CabinetUser
            {
                UserName = "admin@cabinet.com",
                Email = "admin@cabinet.com"
            };
            var result = await UserManager.CreateAsync(admin, "Admin@2022");
            await UserManager.AddToRoleAsync(admin, "Admin");
            Console.WriteLine(result);
        }
    }
}