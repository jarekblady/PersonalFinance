using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Repository.Context;
using PersonalFinance.Repository.Entities;
using PersonalFinance.Service.DTOs;
using PersonalFinance.Service.Services.AccountService;

namespace PersonalFinance.Service
{
    public class DbInitializer
    {
        private readonly FinanceDbContext _context;
        private IAccountService _accountService;

        public DbInitializer(FinanceDbContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        public async Task Initializer()
        {
            if (!_context.Database.CanConnect())
                return;
            if (!_context.Users.Any())
            {
                var userDto = new RegisterUserDto()
                {
                    FirstName = "user",
                    LastName = "user",
                    Email = "user@user.pl",
                    Password = "password",
                };
                await _accountService.RegisterUser(userDto);
            }
            if (!_context.ExpenditureCategories.Any())
            {
                _context.ExpenditureCategories.AddRange(GetExpenditureCategories());
                _context.SaveChanges();
            }
            if (!_context.IncomeCategories.Any())
            {
                _context.IncomeCategories.AddRange(GetIncomeCategories());
                _context.SaveChanges();
            }
        }

        private IEnumerable<ExpenditureCategory> GetExpenditureCategories()
        {
            return new List<ExpenditureCategory>()
            {
                new ExpenditureCategory() {Name = "Food", UserId = 1 },
                new ExpenditureCategory() {Name = "Transport", UserId = 1 },
                new ExpenditureCategory() {Name = "Mobile", UserId = 1 },
                new ExpenditureCategory() {Name = "Internet", UserId = 1 },
                new ExpenditureCategory() {Name = "Entertainment", UserId = 1 },
            };
        }

        private IEnumerable<IncomeCategory> GetIncomeCategories()
        {
            return new List<IncomeCategory>()
            {
                new IncomeCategory() {Name = "Salary", UserId = 1},
                new IncomeCategory() {Name = "Scholarship", UserId = 1},
            };
        }

    }
}