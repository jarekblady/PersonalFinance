using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Repository.Entities;

namespace PersonalFinance.Repository.Repositories.ExpenditureCategoryRepository
{
    public interface IExpenditureCategoryRepository
    {
        Task<List<ExpenditureCategory>> GetAllExpenditureCategories();
        Task<ExpenditureCategory> GetByIdExpenditureCategory(int id);
        Task CreateExpenditureCategory(ExpenditureCategory expenditureCategory);
        Task UpdateExpenditureCategory(ExpenditureCategory expenditureCategory);
        Task DeleteExpenditureCategory(ExpenditureCategory expenditureCategory);
    }
}
