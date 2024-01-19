using Service.Repositories;
using Service.Services;
using Shared.DTOs;
using Shared.Entities;
using BC = BCrypt.Net.BCrypt;

namespace Service
{
    public interface IAuthenticateService
    {
        Task<Response<TokenResponse>> LoginAsync(LoginRequest request);
        Task<Response<bool>> ResetPasswordAsync(ResetPasswordRequest request);
    }

    public class AuthenticateService : IAuthenticateService
    {
        private readonly IAuthenticateRepository _authRepo;
        private readonly IRepository<User> _repository;
        private readonly ITokenService _tokenService;
        public AuthenticateService(IAuthenticateRepository authRepo, ITokenService tokenService, IRepository<User> repository)
        {
            _authRepo = authRepo;
            _tokenService = tokenService;
            _repository = repository;
        }

        public async Task<Response<TokenResponse>> LoginAsync(LoginRequest request)
        {
            var emailExist = await _authRepo.IsEmailExist(request.Email);

            if (emailExist is null)
            {
                return new Response<TokenResponse>
                {
                    Data = default,
                    IsError = true,
                    Message = "Username or Passowrd is invalid!",
                    StatusCode = 404
                };
            }

            var passwordMatch = await _authRepo.IsPasswordMatch(request.Password, emailExist);

            if (!passwordMatch)
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
                Data = _tokenService.GetTokenResponse(emailExist),
                IsError = false,
                Message = "Login successfully!",
                StatusCode = 200
            };
        }

        public async Task<Response<bool>> ResetPasswordAsync(ResetPasswordRequest request)
        {
            User user = await _authRepo.GetUserResetPasswordAsync(request.Email);

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

            await _repository.UpdateAsync(user);

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
