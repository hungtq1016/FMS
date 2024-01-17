using Service.Repositories;
using Service.Services;
using Share.DTOs;
using Share.Entities;

namespace Service
{
    public interface IAuthenticateService
    {
        Task<Response<TokenResponse>> LoginAsync(LoginRequest request);
        Task Logout(RegisterRequest request);
        Task<Response<bool>> RecoverPassword(string id);
    }

    public class AuthenticateService : IAuthenticateService
    {
        private readonly IAuthenticateRepository _authRepo;
        private readonly ITokenService _tokenService;
        public AuthenticateService(IAuthenticateRepository authRepo, ITokenService tokenService)
        {
            _authRepo = authRepo;
            _tokenService = tokenService;
        }

        public async Task<Response<TokenResponse>> LoginAsync(LoginRequest request)
        {
            var emailExist = await _authRepo.IsEmailExist(request.Email);

            if (emailExist is null)
            {
                return new Response<TokenResponse>
                {
                    Data = default(TokenResponse),
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
                    Data = default(TokenResponse),
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

        public Task<Response<bool>> RecoverPassword(string id)
        {
            throw new NotImplementedException();
        }

        public Task Logout(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
