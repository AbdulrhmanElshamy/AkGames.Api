using Microsoft.AspNetCore.Identity;

namespace AkGames.Api.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<RefreshToken>? RefreshTokens { get; set; }
    }
}
