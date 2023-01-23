using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Repository.Entities;

namespace PersonalFinance.Repository.Repositories.IncomeCategoryRepository
{
    public interface IIncomeCategoryRepository
    {
        Task<List<IncomeCategory>> GetAllIncomeCategories();
        Task<IncomeCategory> GetByIdIncomeCategory(int id);
        Task CreateIncomeCategory(IncomeCategory incomeCategory);
        Task UpdateIncomeCategory(IncomeCategory incomeCategory);
        Task DeleteIncomeCategory(IncomeCategory incomeCategory);
    }
}
