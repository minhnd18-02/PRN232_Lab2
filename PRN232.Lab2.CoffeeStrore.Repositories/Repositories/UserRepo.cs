using Microsoft.EntityFrameworkCore;
using PRN232.Lab2.CoffeeStore.Data;
using PRN232.Lab2.CoffeeStore.Data.Entities;
using PRN232.Lab2.CoffeeStrore.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStrore.Repositories.Repositories
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<User?> GetUserByUsernameAndPassword(string username, string password)
        {
            var user = await _context.Users.Include(u => u.Token)
                            .FirstOrDefaultAsync(record => record.Username.Trim().ToLower() == username.Trim().ToLower() && record.Password == password);
            return user;
        }
    }
}
