using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PersonalFinance.Repository.Entities;
using PersonalFinance.Repository.Repositories.IncomeRepository;
using PersonalFinance.Service.DTOs;

namespace PersonalFinance.Service.Services.IncomeService
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IMapper _mapper;

        public IncomeService(IIncomeRepository incomeRepository, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
        }


        public async Task<List<IncomeDto>> GetAllIncomes()
        {
            var incomes = await _incomeRepository.GetAllIncomes();
            
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
