using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AkGames.Api.Dtos
{
    public class GameFormDto
    {
            [MaxLength(250)]
            public string Name { get; set; } = string.Empty;

            [Display(Name = "Category")]
            public int CategoryId { get; set; }

            [Display(Name = "Supported Devices")]
            public List<int> SelectedDevices { get; set; } = default!;

            [MaxLength(2500)]
            public string Description { get; set; } = string.Empty;
        
    }
}
