using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.DTOs;
using Shared.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service
{
    public interface ITokenService
    {
        TokenResponse GetTokenResponse(User user);
        string GetAccessToken(User user);
        Task<string> GetRefreshToken(User user);

    }

    public class TokenService : ITokenService
    {
        private IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public TokenResponse GetTokenResponse(User user)
        {
            return new TokenResponse
            {
                AccessToken = GetAccessToken(user),
                ExpiredTime = DateTime.Now.AddMinutes(ExpiredTime()),
                RefreshToken = user.RefreshToken,
                TokenType = "Bearer"
            };
        }

        public string GetAccessToken(User user)
        {
            List<Claim> claims = new List<Claim> 
            { 
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id!),
            };

            return AccessTokenGenerator(claims);
        }

        public Task<string> GetRefreshToken(User user)
        {
            throw new NotImplementedException();
        }

        private string AccessTokenGenerator(List<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]!));


            var token = new JwtSecurityToken
                (
                    issuer: _config["JWT:ValidIssuer"],
                    audience: _config["JWT:ValidAudience"],
                    expires: DateTime.Now.AddMinutes(ExpiredTime()),
                    claims: claims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private int ExpiredTime() => int.TryParse(_config["JWT:AccessTokenValidityInMinutes"], out int accessTokenValidityInMinutes) ? accessTokenValidityInMinutes : 0;

    }
}
