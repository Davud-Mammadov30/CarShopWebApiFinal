using CarShopWeb.Application.DTOs.CarsDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Validations.CarsValidator
{
    public class UpdateCarValidator : AbstractValidator<UpdateCarsDTO>
    {
        public UpdateCarValidator() 
        {
            RuleFor(x => x.Brand)
            .NotEmpty().WithMessage("Brand is required.")
            .Length(2, 50).WithMessage("Brand must be between 2 and 50 characters.");

            RuleFor(x => x.Model)
                .NotEmpty().WithMessage("Model is required.")
                .Length(1, 50).WithMessage("Model must be between 1 and 50 characters.");

            RuleFor(x => x.Year)
                .InclusiveBetween(1886, DateTime.Now.Year + 1)
                .WithMessage($"Year must be between 1886 and {DateTime.Now.Year + 1}.");

            RuleFor(x => x.BasePrice)
                .GreaterThan(0).WithMessage("Base price must be greater than 0.");

            RuleFor(x => x.DateAdded)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Date added cannot be in the future.");

            RuleFor(x => x.HorsePower)
                .GreaterThan(0).WithMessage("Horsepower must be greater than 0.");

            RuleFor(x => x.Engine)
                .NotEmpty().WithMessage("Engine type is required.")
                .Length(1, 50).WithMessage("Engine type must be between 1 and 50 characters.");

            RuleFor(x => x.EngineCylinder)
                .GreaterThan(0).WithMessage("Engine cylinder count must be greater than 0.");

            RuleFor(x => x.EngineLiter)
                .GreaterThan(0).WithMessage("Engine liter must be greater than 0.");

            RuleFor(x => x.Torque)
                .GreaterThan(0).WithMessage("Torque must be greater than 0.");
        }
    }
}
