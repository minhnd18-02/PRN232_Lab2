using PRN232.Lab2.CoffeeStore.Data;
using PRN232.Lab2.CoffeeStore.Data.Data;
using PRN232.Lab2.CoffeeStore.Data.Entities;
using PRN232.Lab2.CoffeeStore.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repositories.Repositories
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(AppDbContext context) : base(context)
        {
        }
    }
}
