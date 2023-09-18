using System.ComponentModel.DataAnnotations;

namespace AkGames.Api.Core
{
    public class Device : BaseEntity
    {
        [MaxLength(50)]
        public string Icon { get; set; } = string.Empty;
    }
}
