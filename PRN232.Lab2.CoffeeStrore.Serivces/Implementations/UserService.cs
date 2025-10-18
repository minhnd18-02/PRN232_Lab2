using PRN232.Lab2.CoffeeStrore.Repositories;
using PRN232.Lab2.CoffeeStrore.Repositories.IRepositories;
using PRN232.Lab2.CoffeeStrore.Services.Interfaces;
using PRN232.Lab2.CoffeeStrore.Services.ServiceResponse;
using PRN232.Lab2.CoffeeStrore.Services.Ultils;
using PRN232.Lab2.CoffeeStrore.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStrore.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly AppConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork, AppConfiguration appConfiguration)
        {
            _unitOfWork = unitOfWork;
            _config = appConfiguration;
        }
        public async Task<TokenResponse<string>> LoginAsync(LoginUser userObject)
        {
            var response = new TokenResponse<string>();
            try
            {
                var validationContext = new ValidationContext(userObject);
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateObject(userObject, validationContext, validationResults, true))
                {
                    var errorMessages = validationResults.Select(r => !string.IsNullOrWhiteSpace(r.ErrorMessage) ? (string)r.ErrorMessage : string.Empty).ToList();
                    response.Success = false;
                    response.Message = string.Join("; ", errorMessages);
                    response.ErrorMessages = errorMessages;
                    return response;
                }
                var userLogin = await _unitOfWork.UserRepo.GetUserByUsernameAndPassword(userObject.Username, userObject.Password);
                if (userLogin == null)
                {
                    response.Success = false;
                    response.Message = "Invalid username or password";
                    return response;
                }
                var token = await _unitOfWork.TokenRepo.GetTokenByUserIdAsync(userLogin.Id);
                var userId = userLogin.Id;
                var userName = userLogin.Username;
                var tokenJWT = userLogin.GenerateJsonWebToken(_config, _config.JWTSection.SecretKey, DateTime.Now);
                response.Success = true;
                response.Message = "Login Successfully";
                response.DataToken = tokenJWT;
                response.FullName = userName;
                response.HintId = userId;
            }
            catch (DbException ex)
            {
                response.Success = false;
                response.Message = "Database error occurred.";
                response.ErrorMessages = new List<string> { ex.Message };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error";
                response.ErrorMessages = new List<string> { ex.Message };
            }

            return response;
        }
    }
}
