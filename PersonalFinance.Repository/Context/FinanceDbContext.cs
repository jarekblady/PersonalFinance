using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Repository.Entities;

namespace PersonalFinance.Repository.Context
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<ExpenditureCategory> ExpenditureCategories { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
