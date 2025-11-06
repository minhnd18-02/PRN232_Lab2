
using PRN232.Lab2.CoffeeStore.Services.IServices;
using PRN232.Lab2.CoffeeStore.Services.Service;

namespace PRN232.Lab2.CoffeeStore.API
{
    public static class DenpendencyInjections
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
