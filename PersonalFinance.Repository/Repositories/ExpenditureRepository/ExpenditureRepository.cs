using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Repository.Context;
using PersonalFinance.Repository.Entities;
using PersonalFinance.Repository.Queries;

namespace PersonalFinance.Repository.Repositories.ExpenditureRepository
{
    public class ExpenditureRepository : IExpenditureRepository
    {
        private readonly FinanceDbContext _context;

        public ExpenditureRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Expenditure>> GetAllExpenditures(int userId, TransactionQuery query)
        {
            return await _context.Expenditures.Include(x => x.Category)
                .Where(x => x.Category.UserId == userId)
                .Where(x => (query.DateFrom == null || x.Date >= query.DateFrom) && (query.DateTo == null || x.Date <= query.DateTo))
                .Where(x => query.CategoryId == 0 || x.CategoryId == query.CategoryId)
                .OrderByDescending(x => x.Date.Date)
                .ToListAsync();
        }

        public async Task<Expenditure> GetByIdExpenditure(int id)
        {
            return await _context.Expenditures.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task CreateExpenditure(Expenditure expenditure)
        {
            await _context.Expenditures.AddAsync(expenditure);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExpenditure(Expenditure expenditure)
        {
            _context.Expenditures.Update(expenditure);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteExpenditure(Expenditure expenditure)
        {
            _context.Expenditures.Remove(expenditure);
            await _context.SaveChangesAsync();
        }
    }
}
