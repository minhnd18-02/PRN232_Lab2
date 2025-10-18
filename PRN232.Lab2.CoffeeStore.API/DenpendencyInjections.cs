using PRN232.Lab2.CoffeeStrore.Services.Implementations;
using PRN232.Lab2.CoffeeStrore.Services.Interfaces;

namespace PRN232.Lab2.CoffeeStore.API
{
    public static class DenpendencyInjections
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
