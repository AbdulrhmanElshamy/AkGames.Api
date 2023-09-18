using System.ComponentModel.DataAnnotations;

namespace AkGames.Api.Dtos
{
    public class CategoryFormDto
    {
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
    }
}
