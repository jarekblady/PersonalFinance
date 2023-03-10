using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Repository.Context;
using PersonalFinance.Repository.Entities;
using PersonalFinance.Repository.Queries;

namespace PersonalFinance.Repository.Repositories.IncomeCategoryRepository
{
    public class IncomeCategoryRepository : IIncomeCategoryRepository
    {
        private readonly FinanceDbContext _context;

        public IncomeCategoryRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<List<IncomeCategory>> GetAllIncomeCategories(int userId, CategoryQuery query)
        {
            return await _context.IncomeCategories
                .Include(x => x.Incomes.Where(x => (query.DateFrom == null || x.Date >= query.DateFrom) && (query.DateTo == null || x.Date <= query.DateTo)))
                .Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<IncomeCategory> GetByIdIncomeCategory(int id)
        {
            return await _context.IncomeCategories.Include(x => x.Incomes).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task CreateIncomeCategory(IncomeCategory incomeCategory)
        {
            await _context.IncomeCategories.AddAsync(incomeCategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIncomeCategory(IncomeCategory incomeCategory)
        {
            _context.IncomeCategories.Update(incomeCategory);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteIncomeCategory(IncomeCategory incomeCategory)
        {
            _context.IncomeCategories.Remove(incomeCategory);
            await _context.SaveChangesAsync();
        }
    }
}