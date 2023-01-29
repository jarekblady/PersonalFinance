using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PersonalFinance.Service.DTOs;

namespace PersonalFinance.Service.Validators
{
    public class IncomeValidator : AbstractValidator<IncomeDto>
    {
        public IncomeValidator()
        {
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Category is required");
        }
    }
}
