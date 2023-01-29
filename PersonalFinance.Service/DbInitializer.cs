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
            if (!_context.Expenditures.Any())
            {
                _context.Expenditures.AddRange(GetExpenses());
                _context.SaveChanges();
            }

            if (!_context.Incomes.Any())
            {
                _context.Incomes.AddRange(GetIncomes());
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
        private IEnumerable<Expenditure> GetExpenses()
        {
            return new List<Expenditure>()
            {
                new Expenditure() {CategoryId = 1, Price = 30.00, Comment = "breakfast", Date = new DateTime(2023, 1, 1, 00, 00, 00)},
                new Expenditure() {CategoryId = 1, Price = 20.00, Comment = "lunch", Date = new DateTime(2023, 1, 4, 00, 00, 00)},
                new Expenditure() {CategoryId = 2, Price = 80.00, Comment = "train", Date = new DateTime(2023, 1, 7,  00, 00, 00)},
                new Expenditure() {CategoryId = 2, Price = 10.00, Comment = "taxi", Date = new DateTime(2023, 1, 3, 00, 00, 00)},
                new Expenditure() {CategoryId = 2, Price = 20.00, Comment = "bus", Date = new DateTime(2023, 1, 15,  00, 00, 00)},
                new Expenditure() {CategoryId = 3, Price = 50.00, Comment = "mobile", Date = new DateTime(2023, 1, 14, 00, 00, 00)},
                new Expenditure() {CategoryId = 4, Price = 70.00, Comment = "internet", Date = new DateTime(2023, 1, 25,  00, 00, 00)},
                new Expenditure() {CategoryId = 5, Price = 30.00, Comment = "cinema", Date = new DateTime(2023, 1, 20, 00, 00, 00)},
            };
        }
        private IEnumerable<Income> GetIncomes()
        {
            return new List<Income>()
            {
                new Income() { CategoryId = 1, Price = 3000, Comment = "salary", Date = new DateTime(2023, 1, 1, 00, 00, 00)},
                new Income() { CategoryId = 2, Price = 1000, Comment = "scholarship", Date = new DateTime(2023, 1, 15, 00, 00, 00)},
            };
        }

    }
}