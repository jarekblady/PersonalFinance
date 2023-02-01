using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Repository.Entities;
using PersonalFinance.Repository.Queries;

namespace PersonalFinance.Repository.Repositories.IncomeCategoryRepository
{
    public interface IIncomeCategoryRepository
    {
        Task<List<IncomeCategory>> GetAllIncomeCategories(int userId, CategoryQuery query);
        Task<IncomeCategory> GetByIdIncomeCategory(int id);
        Task CreateIncomeCategory(IncomeCategory incomeCategory);
        Task UpdateIncomeCategory(IncomeCategory incomeCategory);
        Task DeleteIncomeCategory(IncomeCategory incomeCategory);
    }
}
