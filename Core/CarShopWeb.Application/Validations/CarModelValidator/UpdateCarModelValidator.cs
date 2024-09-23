using CarShopWeb.Application.DTOs.CarModelDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Validations.CarModelValidator
{
    public class UpdateCarModelValidator : AbstractValidator<UpdateCarModelDTO>
    {
        public UpdateCarModelValidator() 
        {
            RuleFor(x => x.CarBrandID)
                .GreaterThan(0).WithMessage("Car brand ID must be a positive number.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Model name is required.")
                .Length(1, 50).WithMessage("Model name must be between 1 and 50 characters.");
        }
    }
}
