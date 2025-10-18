using PRN232.Lab2.CoffeeStore.Data;
using PRN232.Lab2.CoffeeStrore.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStrore.Repositories.Repositories
{
    public class OrderDetailRepo : GenericRepo<OrderDetail>, IOrderDetailRepo
    {
        public OrderDetailRepo(AppDbContext context) : base(context)
        {
        }
    }
}
