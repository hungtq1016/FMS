﻿namespace Infrastructure.OAuth2.Models.DTOs
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public DateTime ExpiredTime { get; set; }
        public string RefreshToken { get; set; }
    }
}
