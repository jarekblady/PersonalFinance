using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Repository.Context;
using PersonalFinance.Repository.Entities;
using PersonalFinance.Repository.Queries;

namespace PersonalFinance.Repository.Repositories.IncomeRepository
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly FinanceDbContext _context;

        public IncomeRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Income>> GetAllIncomes(int userId, TransactionQuery query)
        {
            return await _context.Incomes.Include(x => x.Category)
                .Where(x => x.Category.UserId == userId)
                .Where(x => (query.DateFrom == null || x.Date >= query.DateFrom) && (query.DateTo == null || x.Date <= query.DateTo))
                .Where(x => query.CategoryId == 0 || x.CategoryId == query.CategoryId)
                .OrderByDescending(x => x.Date.Date)
                .ToListAsync();
        }

        public async Task<Income> GetByIdIncome(int id)
        {
            return await _context.Incomes.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task CreateIncome(Income income)
        {
            await _context.Incomes.AddAsync(income);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIncome(Income income)
        {
            _context.Incomes.Update(income);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteIncome(Income income)
        {
            _context.Incomes.Remove(income);
            await _context.SaveChangesAsync();
        }
    }
}

