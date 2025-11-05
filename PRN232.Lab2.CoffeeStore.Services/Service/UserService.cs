using AutoMapper;
using PRN232.Lab2.CoffeeStore.Data.Entities;
using PRN232.Lab2.CoffeeStore.Repositories.IRepositories;
using PRN232.Lab2.CoffeeStore.Services.IServices;
using PRN232.Lab2.CoffeeStore.Services.ViewModels;
using PRN232.Lab2.CoffeeStore.Services.ViewModels.Auths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, ITokenService tokenService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<LoginResponse>> Login(LoginRequest loginRequest)
        {
            var response = new ServiceResponse<LoginResponse>();
            try
            {
                var check = await _unitOfWork.UserRepo.FindEntityAsync(p => p.Username.Equals(loginRequest.UserName) && p.Password.Equals(loginRequest.Password));
                if (check == null)
                {
                    response.Success = false;
                    response.Message = "Invalid username or password";
                    return response;
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, check.Id.ToString() ?? "NoId"),
                    new Claim(ClaimTypes.Name, check.Username),
                    new Claim(ClaimTypes.Role, check.Role ?? "User")
                };

                var accessToken = _tokenService.GenerateAccessToken(claims);
                var refreshToken = _tokenService.GenerateRefreshToken();

                var token = new Token
                {
                    UserId = check.Id,
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7),
                    CreatedAt = DateTime.UtcNow,
                };

                await _unitOfWork.TokenRepo.AddAsync(token);

                response.Success = true;
                response.Message = "Login successfully";
                response.Data = _mapper.Map<LoginResponse>(token);

            } catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }
    }
}
