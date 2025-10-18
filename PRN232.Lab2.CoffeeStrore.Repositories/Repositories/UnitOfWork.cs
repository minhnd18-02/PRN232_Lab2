using PRN232.Lab2.CoffeeStore.Data;
using PRN232.Lab2.CoffeeStrore.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStrore.Repositories.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICategoryRepo _categoryRepo;
        private readonly IOrderRepo _orderRepo;
        private readonly IOrderDetailRepo _orderDetailRepo;
        private readonly IPaymentRepo _paymentRepo;
        private readonly IProductRepo _productRepo;
        private readonly IUserRepo _userRepo;
        private readonly ITokenRepo _tokenRepo;
        public UnitOfWork(AppDbContext appDbContext, IProductRepo productRepo, ICategoryRepo categoryRepo, IOrderDetailRepo orderDetailRepo, IOrderRepo orderRepo, IPaymentRepo paymentRepo, IUserRepo userRepo, ITokenRepo tokenRepo)
        {
            _appDbContext = appDbContext;
            _categoryRepo = categoryRepo;
            _orderRepo = orderRepo;
            _orderDetailRepo = orderDetailRepo;
            _paymentRepo = paymentRepo;
            _productRepo = productRepo;
            _userRepo = userRepo;
            _tokenRepo = tokenRepo;
        }

        public ICategoryRepo CategoryRepo => _categoryRepo;
        public IOrderRepo OrderRepo => _orderRepo;
        public IOrderDetailRepo OrderDetailRepo => _orderDetailRepo;
        public IPaymentRepo PaymentRepo => _paymentRepo;
        public IProductRepo ProductRepo => _productRepo;
        public IUserRepo UserRepo => _userRepo;
        public ITokenRepo TokenRepo => _tokenRepo;

        public async Task<int> SaveChangeAsync()
        {
            try
            {
                return await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while saving changes.", ex);
            }
        }
    }
}
