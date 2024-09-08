using CarShopWeb.Application.DTOs.OrdersDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Validations.OrdersValidator
{
    public class CreateOrderValidator : AbstractValidator<CreateOrdersDTO>
    {
        public CreateOrderValidator() 
        {
            RuleFor(x => x.CustomerID)
            .GreaterThan(0).WithMessage("Customer ID must be greater than 0.");

            RuleFor(x => x.CarID)
                .GreaterThan(0).WithMessage("Car ID must be greater than 0.");

            RuleFor(x => x.OrderDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Order date cannot be in the future.");

            RuleFor(x => x.TotalPrice)
                .GreaterThan(0).WithMessage("Total price must be greater than 0.");
        }
    }
}
