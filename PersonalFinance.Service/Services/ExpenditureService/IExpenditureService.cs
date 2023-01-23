using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Service.DTOs;

namespace PersonalFinance.Service.Services.ExpenditureService
{
    public interface IExpenditureService
    {
        Task<List<ExpenditureDto>> GetAllExpenditures();
        Task<ExpenditureDto> GetByIdExpenditure(int id);
        Task CreateExpenditure(ExpenditureDto dto);
        Task UpdateExpenditure(ExpenditureDto dto);
        Task DeleteExpenditure(int id);
    }
}
