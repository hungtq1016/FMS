using Infrastructure.OAuth2.DTOs;
using Infrastructure.OAuth2.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.OAuth2.Data.Services;

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
            RefreshToken = Guid.NewGuid().ToString(),
            TokenType = "Beared"
        };
    }

    public string GetAccessToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, user.FullName),
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
