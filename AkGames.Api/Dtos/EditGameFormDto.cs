using AkGames.Api.Attributes;
using AkGames.Api.Settings;

namespace AkGames.Api.Dtos
{
    public class EditGameFormDto : GameFormDto
    {
            public int Id { get; set; }

            public string? CurrentCover { get; set; }

            [AllowedExtensions(FileSettings.AllowedExtensions),
                MaxFileSize(FileSettings.MaxFileSizeInBytes)]
            public IFormFile? Cover { get; set; } = default!;
    }
}
