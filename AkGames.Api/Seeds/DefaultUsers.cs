using AkGames.Api.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace AkGames.Api.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser admin = new()
            {
                UserName = "admin",
                Email = "admin@AkGames.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(admin.Email);

            if (user is null)
            {
                await userManager.CreateAsync(admin, "P@ssword123");
            }
        }
    }
}
