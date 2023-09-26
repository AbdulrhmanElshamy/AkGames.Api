using System.ComponentModel.DataAnnotations;

namespace AkGames.Api.Dtos
{
    public class TokenRequestDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
