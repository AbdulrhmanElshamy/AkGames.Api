namespace AkGames.Api.Dtos
{
    public class GameGitDto : GameFormDto
    {
        public int Id { get; set; }
        public string CoverUrl { get; set; } = string.Empty;
    }
}
