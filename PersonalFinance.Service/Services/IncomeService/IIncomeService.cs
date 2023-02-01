using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Repository.Queries;
using PersonalFinance.Service.DTOs;

namespace PersonalFinance.Service.Services.IncomeService
{
    public interface IIncomeService
    {
        Task<List<IncomeDto>> GetAllIncomes(TransactionQuery query);
        Task<IncomeDto> GetByIdIncome(int id);
        Task CreateIncome(IncomeDto dto);
        Task UpdateIncome(IncomeDto dto);
        Task DeleteIncome(int id);
    }
}
