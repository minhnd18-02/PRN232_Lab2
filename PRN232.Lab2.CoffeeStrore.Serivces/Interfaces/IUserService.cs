using PRN232.Lab2.CoffeeStrore.Services.ServiceResponse;
using PRN232.Lab2.CoffeeStrore.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStrore.Services.Interfaces
{
    public interface IUserService
    {
        public Task<TokenResponse<string>> LoginAsync(LoginUser userObject);
    }
}
