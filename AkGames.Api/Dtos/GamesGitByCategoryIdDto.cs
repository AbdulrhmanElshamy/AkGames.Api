namespace AkGames.Api.Dtos
{
    public class GamesGitByCategoryIdDto
    {
        public int CategoryId { get; set; }

        public IList<GameGitDto> Games { get; set; }
    }
}
