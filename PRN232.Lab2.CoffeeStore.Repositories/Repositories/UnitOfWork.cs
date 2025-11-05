using PRN232.Lab2.CoffeeStore.Data;
using PRN232.Lab2.CoffeeStore.Data.Data;
using PRN232.Lab2.CoffeeStore.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repositories.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICategoryRepo _categoryRepo;
        private readonly IOrderDetailRepo _orderDetailRepo;
        private readonly IOrderRepo _orderRepo;
        private readonly IPaymentRepo _paymentRepo;
        private readonly IProductRepo _productRepo;
        private readonly ITokenRepo _tokenRepo;
        private readonly IUserRepo _userRepo;

        public UnitOfWork(AppDbContext appDbContext, ICategoryRepo categoryRepo, IOrderDetailRepo orderDetailRepo, 
            IOrderRepo orderRepo, IPaymentRepo paymentRepo, IProductRepo productRepo, ITokenRepo tokenRepo, IUserRepo userRepo)
        {
            _appDbContext = appDbContext;
            _categoryRepo = categoryRepo;
            _orderDetailRepo = orderDetailRepo;
            _orderRepo = orderRepo;
            _paymentRepo = paymentRepo;
            _productRepo = productRepo;
            _tokenRepo = tokenRepo;
            _userRepo = userRepo;
        }

        public ICategoryRepo CategoryRepo => _categoryRepo;
        public IOrderDetailRepo OrderDetailRepo => _orderDetailRepo;
        public IOrderRepo OrderRepo => _orderRepo;
        public IPaymentRepo PaymentRepo => _paymentRepo;
        public ITokenRepo TokenRepo => _tokenRepo;
        public IProductRepo ProductRepo => _productRepo;
        public IUserRepo UserRepo => _userRepo;

        public async Task<int> SaveChangeAsync()
        {
            try
            {
                return await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception details here
                throw new ApplicationException("An error occurred while saving changes.", ex);
            }
        }
    }
}
