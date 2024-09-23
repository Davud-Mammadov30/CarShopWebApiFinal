using CarShopWeb.Application.DTOs.CarBrandDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Validations.CarBrandValidator
{
    public class CreateCarBrandValidator : AbstractValidator<CreateCarBrandDTO>
    {
        public CreateCarBrandValidator() 
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Brand name is required.")
            .Length(2, 50).WithMessage("Brand name must be between 2 and 50 characters.");
        }    

    }
}
