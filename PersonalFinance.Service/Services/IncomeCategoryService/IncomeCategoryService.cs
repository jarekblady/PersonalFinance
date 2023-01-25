using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PersonalFinance.Repository.Entities;
using PersonalFinance.Repository.Repositories.IncomeCategoryRepository;
using PersonalFinance.Service.DTOs;
using PersonalFinance.Service.Services.CurrentUserService;

namespace PersonalFinance.Service.Services.IncomeCategoryService
{
    public class IncomeCategoryService : IIncomeCategoryService
    {
        private readonly IIncomeCategoryRepository _incomeCategoryRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public IncomeCategoryService(IIncomeCategoryRepository incomeCategoryRepository, ICurrentUserService currentUserService, IMapper mapper)
        {
            _incomeCategoryRepository = incomeCategoryRepository;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }


        public async Task<List<IncomeCategoryDto>> GetAllIncomeCategories()
        {
            var userId = _currentUserService.GetCurrentUserId();
            var incomeCategories = await _incomeCategoryRepository.GetUserIncomeCategories(userId);

            return _mapper.Map<List<IncomeCategoryDto>>(incomeCategories);
        }

        public async Task<IncomeCategoryDto> GetByIdIncomeCategory(int id)
        {
            var incomeCategory = await _incomeCategoryRepository.GetByIdIncomeCategory(id);
            return _mapper.Map<IncomeCategoryDto>(incomeCategory);
        }


        public async Task CreateIncomeCategory(IncomeCategoryDto dto)
        {
            var incomeCategory = _mapper.Map<IncomeCategory>(dto);
            incomeCategory.UserId = _currentUserService.GetCurrentUserId();
            await _incomeCategoryRepository.CreateIncomeCategory(incomeCategory);
        }

        public async Task UpdateIncomeCategory(IncomeCategoryDto dto)
        {
            var incomeCategory = _mapper.Map<IncomeCategory>(dto);
            incomeCategory.UserId = _currentUserService.GetCurrentUserId();
            await _incomeCategoryRepository.UpdateIncomeCategory(incomeCategory);
        }

        public async Task DeleteIncomeCategory(int id)
        {
            var incomeCategory = await _incomeCategoryRepository.GetByIdIncomeCategory(id);
            _incomeCategoryRepository.DeleteIncomeCategory(incomeCategory);
        }
    }
}
