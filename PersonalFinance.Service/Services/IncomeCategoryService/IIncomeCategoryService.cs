using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Repository.Queries;
using PersonalFinance.Service.DTOs;

namespace PersonalFinance.Service.Services.IncomeCategoryService
{
    public interface IIncomeCategoryService
    {
        Task<List<IncomeCategoryDto>> GetAllIncomeCategories(CategoryQuery query);
        Task<IncomeCategoryDto> GetByIdIncomeCategory(int id);
        Task CreateIncomeCategory(IncomeCategoryDto dto);
        Task UpdateIncomeCategory(IncomeCategoryDto dto);
        Task DeleteIncomeCategory(int id);
    }
}
