﻿using System.Text.Json.Serialization;

namespace AkGames.Api.Dtos
{
    public class AuthDto
    {
        public string Message { get; set; } = string.Empty;

        public bool IsAuthenticated { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;

        public DateTime ExpiresOn { get; set; }

        [JsonIgnore]
        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiration { get; set; }
    }
}
