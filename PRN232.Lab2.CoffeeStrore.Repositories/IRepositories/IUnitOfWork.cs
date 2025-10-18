using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStrore.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        public ICategoryRepo CategoryRepo { get; }
        public IOrderDetailRepo OrderDetailRepo { get; }
        public IOrderRepo OrderRepo { get; }
        public IProductRepo ProductRepo { get; }
        public IPaymentRepo PaymentRepo { get; }
        public IUserRepo UserRepo { get; }
        public ITokenRepo TokenRepo { get; }

        public Task<int> SaveChangeAsync();
    }
}
