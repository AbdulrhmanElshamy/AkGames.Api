using Microsoft.EntityFrameworkCore;

namespace AkGames.Api.Core
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category : BaseEntity
    {
        public ICollection<Game> Games { get; set; } = new List<Game>();

    }
}
