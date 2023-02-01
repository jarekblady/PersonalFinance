using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Repository.Queries;
using PersonalFinance.Service.DTOs;

namespace PersonalFinance.Service.Services.ExpenditureCategoryService
{
    public interface IExpenditureCategoryService
    {
        Task<List<ExpenditureCategoryDto>> GetAllExpenditureCategories(CategoryQuery query);
        Task<ExpenditureCategoryDto> GetByIdExpenditureCategory(int id);
        Task CreateExpenditureCategory(ExpenditureCategoryDto dto);
        Task UpdateExpenditureCategory(ExpenditureCategoryDto dto);
        Task DeleteExpenditureCategory(int id);
    }
}
