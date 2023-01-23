using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Repository.Entities;

namespace PersonalFinance.Repository.Repositories.AccountRepository
{
    public interface IAccountRepository
    {
        Task<User> GetUserByEmail(string email);
        Task CreateUser(User user);
    }
}
