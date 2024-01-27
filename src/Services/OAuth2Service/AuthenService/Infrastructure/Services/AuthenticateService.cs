using Authenticate.Service.DTOs;
using Infrastructure.EFCore.DTOs;
using Infrastructure.EFCore.Repository;
using Infrastructure.OAuth2.Data.Services;
using Infrastructure.OAuth2.DTOs;
using Infrastructure.OAuth2.Models;
using System.Linq.Expressions;
using BC = BCrypt.Net.BCrypt;

namespace AuthenService.Infrastructure
{ 
    public interface IAuthenticateService
    {
        Task<Response<TokenResponse>> LoginAsync(LoginRequest request);
        Task<Response<bool>> ResetPasswordAsync(ResetPasswordRequest request);
    }

    public class AuthenticateService : IAuthenticateService
    {
        private readonly IRepository<User> _repository;
        private readonly ITokenService _tokenService;
        public AuthenticateService(ITokenService tokenService, IRepository<User> repository)
        {
            _tokenService = tokenService;
            _repository = repository;
        }

        public async Task<Response<TokenResponse>> LoginAsync(LoginRequest request)
        {
            var user = await _repository
                        .FindOneAsync(conditions: new Expression<Func<User, bool>>[]
                            {
                                user => user.Email == request.Email
                            });

            if (user is null || !BC.Verify(request.Password, user.Password))
            {
                return new Response<TokenResponse>
                {
                    Data = default,
                    IsError = true,
                    Message = "Username or Passowrd is invalid!",
                    StatusCode = 404
                };
            }

            return new Response<TokenResponse>
            {
                Data = await _tokenService.GetTokenResponseAsync(user),
                IsError = false,
                Message = "Login successfully!",
                StatusCode = 200
            };
        }

        public async Task<Response<bool>> ResetPasswordAsync(ResetPasswordRequest request)
        {
            User user = await _repository
                        .FindOneAsync(conditions: new Expression<Func<User, bool>>[]
                            {
                                user => user.Email == request.Email
                            });

            if (user is null)
            {
                return new Response<bool>
                {
                    Data = default,
                    IsError = true,
                    Message = "Email wrong or time expired",
                    StatusCode = 404
                };
            }

            user.Password = BC.HashPassword(request.Password);

            await _repository.EditAsync(user);

            return new Response<bool>
            {
                Data = true,
                IsError = false,
                Message = "Password successfully reset",
                StatusCode = 200
            };
        }
    }
}
