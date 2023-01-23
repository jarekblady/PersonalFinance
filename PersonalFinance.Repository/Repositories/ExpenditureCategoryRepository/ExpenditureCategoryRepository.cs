using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Repository.Context;
using PersonalFinance.Repository.Entities;

namespace PersonalFinance.Repository.Repositories.ExpenditureCategoryRepository
{
    public class ExpenditureCategoryRepository : IExpenditureCategoryRepository
    {
        private readonly FinanceDbContext _context;

        public ExpenditureCategoryRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExpenditureCategory>> GetAllExpenditureCategories()
        {
            return await _context.ExpenditureCategories.Include(x => x.Expenditures).ToListAsync();
        }

        public async Task<ExpenditureCategory> GetByIdExpenditureCategory(int id)
        {
            return await _context.ExpenditureCategories.Include(x => x.Expenditures).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task CreateExpenditureCategory(ExpenditureCategory expenditureCategory)
        {
            await _context.ExpenditureCategories.AddAsync(expenditureCategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExpenditureCategory(ExpenditureCategory expenditureCategory)
        {
            _context.ExpenditureCategories.Update(expenditureCategory);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteExpenditureCategory(ExpenditureCategory expenditureCategory)
        {
            _context.ExpenditureCategories.Remove(expenditureCategory);
            await _context.SaveChangesAsync();
        }
    }
}
