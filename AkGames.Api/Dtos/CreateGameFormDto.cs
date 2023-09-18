using AkGames.Api.Attributes;
using AkGames.Api.Settings;

namespace AkGames.Api.Dtos
{
    public class CreateGameFormDto : GameFormDto
    {
            [AllowedExtensions(FileSettings.AllowedExtensions),
                MaxFileSize(FileSettings.MaxFileSizeInBytes)]
            public IFormFile Cover { get; set; } = default!;
    }
}
