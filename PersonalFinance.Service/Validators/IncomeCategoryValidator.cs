using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PersonalFinance.Service.DTOs;

namespace PersonalFinance.Service.Validators
{
    public class IncomeCategoryValidator : AbstractValidator<IncomeCategoryDto>
    {
        public IncomeCategoryValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(1).WithMessage("Name is required");
        }
    }
}