using Microsoft.Extensions.DependencyInjection;
using PRN232.Lab2.CoffeeStore.Data;
using PRN232.Lab2.CoffeeStrore.Repositories.IRepositories;
using PRN232.Lab2.CoffeeStrore.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStrore.Repositories
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<ITokenRepo, TokenRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IOrderDetailRepo, OrderDetailRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IPaymentRepo, PaymentRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
