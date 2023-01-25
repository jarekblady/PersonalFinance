using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Repository.Entities;

namespace PersonalFinance.Repository.Repositories.ExpenditureRepository
{
    public interface IExpenditureRepository
    {
        Task<List<Expenditure>> GetAllExpenditures(int userId);
        Task<Expenditure> GetByIdExpenditure(int id);
        Task CreateExpenditure(Expenditure expenditure);
        Task UpdateExpenditure(Expenditure expenditure);
        Task DeleteExpenditure(Expenditure expenditure);
    }
}
