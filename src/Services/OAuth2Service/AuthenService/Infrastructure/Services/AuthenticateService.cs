using Authenticate.Service.DTOs;
using Infrastructure.EFCore.DTOs;
using Infrastructure.EFCore.Helpers;
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
            User user = await FindByUserAsync(request.Email);
                            
            if (user is null || !BC.Verify(request.Password, user.Password))
            {
                return ResponseHelper.CreateNotFoundResponse<TokenResponse>("Username or Passowrd is invalid!");
            }

            return ResponseHelper.CreateSuccessResponse(await _tokenService.GetTokenResponseAsync(user));
        }

        public async Task<Response<bool>> ResetPasswordAsync(ResetPasswordRequest request)
        {
            User user = await FindByUserAsync(request.Email);

            if (user is null)
                return ResponseHelper.CreateNotFoundResponse<bool>("Email wrong or time expired");

            user.Password = BC.HashPassword(request.Password);

            await _repository.EditAsync(user);

            return ResponseHelper.CreateSuccessResponse(true);
        }

        private async Task<User> FindByUserAsync(string email)
        {
            return await _repository
                        .FindOneAsync(conditions: new Expression<Func<User, bool>>[]
                        {
                                user => user.Email == email
                            });
        }
    }
}
