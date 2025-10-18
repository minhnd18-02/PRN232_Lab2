using PRN232.Lab2.CoffeeStore.Data;
using PRN232.Lab2.CoffeeStrore.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStrore.Repositories.Repositories
{
    public class PaymentRepo : GenericRepo<Payment>, IPaymentRepo
    {
        public PaymentRepo(AppDbContext context) : base(context)
        {
        }
    }
}
