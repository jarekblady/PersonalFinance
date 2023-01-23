using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Service.DTOs;

namespace PersonalFinance.Service.Services.ExpenditureCategoryService
{
    public interface IExpenditureCategoryService
    {
        Task<List<ExpenditureCategoryDto>> GetAllExpenditureCategories();
        Task<ExpenditureCategoryDto> GetByIdExpenditureCategory(int id);
        Task CreateExpenditureCategory(ExpenditureCategoryDto dto);
        Task UpdateExpenditureCategory(ExpenditureCategoryDto dto);
        Task DeleteExpenditureCategory(int id);
    }
}
