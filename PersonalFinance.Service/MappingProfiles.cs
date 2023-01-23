using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PersonalFinance.Repository.Entities;
using PersonalFinance.Service.DTOs;

namespace PersonalFinance.Service
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Income, IncomeDto>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name));
            CreateMap<IncomeDto, Income>();

            CreateMap<Expenditure, ExpenditureDto>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name));
            CreateMap<ExpenditureDto, Expenditure>();

            CreateMap<IncomeCategory, IncomeCategoryDto>();
            CreateMap<IncomeCategoryDto, IncomeCategory>();

            CreateMap<ExpenditureCategory, ExpenditureCategoryDto>();
            CreateMap<ExpenditureCategoryDto, ExpenditureCategory>();

        }
    }
}
