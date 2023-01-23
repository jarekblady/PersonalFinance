using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Repository.Context;
using PersonalFinance.Repository.Entities;

namespace PersonalFinance.Repository.Repositories.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly FinanceDbContext _context;

        public AccountRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return  await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
