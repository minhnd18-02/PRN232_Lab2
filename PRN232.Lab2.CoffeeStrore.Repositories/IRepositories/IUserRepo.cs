using PRN232.Lab2.CoffeeStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStrore.Repositories.IRepositories
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task<User?> GetUserByUsernameAndPassword(string username, string password);
    }
}
