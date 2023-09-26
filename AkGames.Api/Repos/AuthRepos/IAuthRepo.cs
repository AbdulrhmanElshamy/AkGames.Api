using AkGames.Api.Dtos;

namespace AkGames.Api.Repos.AuthRepos
{
    public interface IAuthRepo
    {
        Task<AuthDto> GetTokenAsync(TokenRequestDto model);
        Task<AuthDto> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);
    }
}
