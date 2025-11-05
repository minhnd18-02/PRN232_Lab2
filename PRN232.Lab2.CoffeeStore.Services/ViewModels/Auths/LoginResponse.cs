using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Services.ViewModels.Auths
{
    public class LoginResponse
    {
        public string? AccessToken { get; set; }

        public string RefreshToken { get; set; } = null!;
    }
}
