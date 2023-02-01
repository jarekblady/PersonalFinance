using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PersonalFinance.Repository.Entities;
using PersonalFinance.Repository.Queries;
using PersonalFinance.Repository.Repositories.IncomeRepository;
using PersonalFinance.Service.DTOs;
using PersonalFinance.Service.Services.CurrentUserService;

namespace PersonalFinance.Service.Services.IncomeService
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public IncomeService(IIncomeRepository incomeRepository, ICurrentUserService currentUserService, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }


        public async Task<List<IncomeDto>> GetAllIncomes(TransactionQuery query)
        {
            var userId = _currentUserService.GetCurrentUserId();
            var incomes = await _incomeRepository.GetAllIncomes(userId, query);
            
            return _mapper.Map<List<IncomeDto>>(incomes);
        }

        public async Task<IncomeDto> GetByIdIncome(int id)
        {
            var income = await _incomeRepository.GetByIdIncome(id);
            return _mapper.Map<IncomeDto>(income);
        }


        public async Task CreateIncome(IncomeDto dto)
        {
            var income = _mapper.Map<Income>(dto);
            await _incomeRepository.CreateIncome(income);
        }

        public async Task UpdateIncome(IncomeDto dto)
        {
            var income = _mapper.Map<Income>(dto);
            await _incomeRepository.UpdateIncome(income);
        }

        public async Task DeleteIncome(int id)
        {
            var income = await _incomeRepository.GetByIdIncome(id);
            _incomeRepository.DeleteIncome(income);
        }
    }
}
