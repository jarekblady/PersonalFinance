using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PersonalFinance.Repository.Entities;
using PersonalFinance.Repository.Queries;
using PersonalFinance.Repository.Repositories.ExpenditureCategoryRepository;
using PersonalFinance.Service.DTOs;
using PersonalFinance.Service.Services.CurrentUserService;

namespace PersonalFinance.Service.Services.ExpenditureCategoryService
{
    public class ExpenditureCategoryService : IExpenditureCategoryService
    {
        private readonly IExpenditureCategoryRepository _expenditureCategoryRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public ExpenditureCategoryService(IExpenditureCategoryRepository expenditureCategoryRepository, ICurrentUserService currentUserService, IMapper mapper)
        {
            _expenditureCategoryRepository = expenditureCategoryRepository;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }


        public async Task<List<ExpenditureCategoryDto>> GetAllExpenditureCategories(CategoryQuery query)
        {
            var userId = _currentUserService.GetCurrentUserId();
            var expenditureCategories = await _expenditureCategoryRepository.GetAllExpenditureCategories(userId, query);

            return _mapper.Map<List<ExpenditureCategoryDto>>(expenditureCategories);
        }

        public async Task<ExpenditureCategoryDto> GetByIdExpenditureCategory(int id)
        {
            var expenditureCategory = await _expenditureCategoryRepository.GetByIdExpenditureCategory(id);
            return _mapper.Map<ExpenditureCategoryDto>(expenditureCategory);
        }


        public async Task CreateExpenditureCategory(ExpenditureCategoryDto dto)
        {
            var expenditureCategory = _mapper.Map<ExpenditureCategory>(dto);
            expenditureCategory.UserId = _currentUserService.GetCurrentUserId();
            await _expenditureCategoryRepository.CreateExpenditureCategory(expenditureCategory);
        }

        public async Task UpdateExpenditureCategory(ExpenditureCategoryDto dto)
        {
            var expenditureCategory = _mapper.Map<ExpenditureCategory>(dto);
            expenditureCategory.UserId = _currentUserService.GetCurrentUserId();
            await _expenditureCategoryRepository.UpdateExpenditureCategory(expenditureCategory);
        }

        public async Task DeleteExpenditureCategory(int id)
        {
            var expenditureCategory = await _expenditureCategoryRepository.GetByIdExpenditureCategory(id);
            _expenditureCategoryRepository.DeleteExpenditureCategory(expenditureCategory);
        }
    }
}

