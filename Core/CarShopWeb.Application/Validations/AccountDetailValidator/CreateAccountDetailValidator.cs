using CarShopWeb.Application.DTOs.AccountDetailDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Validations.AccountDetailValidator
{
    public class CreateAccountDetailValidator : AbstractValidator<CreateAccountDetailDTO>
    {
        public CreateAccountDetailValidator() 
        {
            RuleFor(x => x.CustomerID)
            .GreaterThan(0).WithMessage("Customer ID must be greater than 0.");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Account code is required.")
                .Length(2, 20).WithMessage("Account code must be between 2 and 20 characters.");

            RuleFor(x => x.Money)
                .GreaterThanOrEqualTo(0).WithMessage("Money must be greater than or equal to 0.");
        }
    }
}
