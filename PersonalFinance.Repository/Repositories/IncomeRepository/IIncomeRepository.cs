using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Repository.Entities;
using PersonalFinance.Repository.Queries;

namespace PersonalFinance.Repository.Repositories.IncomeRepository
{
    public interface IIncomeRepository
    {
        Task<List<Income>> GetAllIncomes(int userId, TransactionQuery query);
        Task<Income> GetByIdIncome(int id);
        Task CreateIncome(Income income);
        Task UpdateIncome(Income income);
        Task DeleteIncome(Income income);
    }
}