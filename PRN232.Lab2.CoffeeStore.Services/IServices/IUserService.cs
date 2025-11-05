using PRN232.Lab2.CoffeeStore.Data.Entities;
using PRN232.Lab2.CoffeeStore.Services.ViewModels;
using PRN232.Lab2.CoffeeStore.Services.ViewModels.Auths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Services.IServices
{
    public interface IUserService
    {
        Task<ServiceResponse<LoginResponse>> Login(LoginRequest loginRequest);
    }
}
