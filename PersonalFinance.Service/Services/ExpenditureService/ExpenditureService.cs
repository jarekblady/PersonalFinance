using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PersonalFinance.Repository.Entities;
using PersonalFinance.Repository.Repositories.ExpenditureRepository;
using PersonalFinance.Service.DTOs;

namespace PersonalFinance.Service.Services.ExpenditureService
{
    public class ExpenditureService : IExpenditureService
    {
        private readonly IExpenditureRepository _expenditureRepository;
        private readonly IMapper _mapper;

        public ExpenditureService(IExpenditureRepository expenditureRepository, IMapper mapper)
        {
            _expenditureRepository = expenditureRepository;
            _mapper = mapper;
        }


        public async Task<List<ExpenditureDto>> GetAllExpenditures()
        {
            var expenditures = await _expenditureRepository.GetAllExpenditures();

            return _mapper.Map<List<ExpenditureDto>>(expenditures);
        }

        public async Task<ExpenditureDto> GetByIdExpenditure(int id)
        {
            var expenditure = await _expenditureRepository.GetByIdExpenditure(id);
            return _mapper.Map<ExpenditureDto>(expenditure);
        }


        public async Task CreateExpenditure(ExpenditureDto dto)
        {
            var expenditure = _mapper.Map<Expenditure>(dto);
            await _expenditureRepository.CreateExpenditure(expenditure);
        }

        public async Task UpdateExpenditure(ExpenditureDto dto)
        {
            var expenditure = _mapper.Map<Expenditure>(dto);
            await _expenditureRepository.UpdateExpenditure(expenditure);
        }

        public async Task DeleteExpenditure(int id)
        {
            var expenditure = await _expenditureRepository.GetByIdExpenditure(id);
            _expenditureRepository.DeleteExpenditure(expenditure);
        }
    }
}

