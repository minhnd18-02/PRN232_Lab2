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
    public class TokenRepo : GenericRepo<Token>, ITokenRepo
    {
        public TokenRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<Token?> GetTokenByUserIdAsync(int userId)
                       => await _context.Tokens
                               .FirstOrDefaultAsync(t => t.UserId == userId);

        public async Task<Token?> GetTokenWithUser(string tokenValue, string type)
        {
            return await _context.Tokens
                                .Include(t => t.User)
                                .FirstOrDefaultAsync(t => t.TokenValue == tokenValue && t.Type == type);
        }
        public async Task<Token?> GetTokenByValueAsync(String tokenValue)
        {
            return await _context.Tokens.FirstOrDefaultAsync(t => t.TokenValue == tokenValue);
        }
    }
}
