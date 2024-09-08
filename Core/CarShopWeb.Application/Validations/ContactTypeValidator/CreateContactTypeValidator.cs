using CarShopWeb.Application.DTOs.ContactTypeDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Validations.OrderDetailsValidator
{
    public class CreateContactTypeValidator : AbstractValidator<CreateContactTypeDTO>
    {
        public CreateContactTypeValidator() 
        {
            RuleFor(x => x.CustomerID)
            .GreaterThan(0).WithMessage("Customer ID must be greater than 0.");

            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Contact number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Contact number must be a valid phone number.");

            RuleFor(x => x.WhatsAppNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$").When(x => !string.IsNullOrEmpty(x.WhatsAppNumber))
                .WithMessage("WhatsApp number must be a valid phone number.");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("Email must be a valid email address.");
        }
    }
}
