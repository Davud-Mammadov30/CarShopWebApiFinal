using CarShopWeb.Application.DTOs.PaymentsDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Validations.PaymentsValidator
{
    public class CreatePaymentValidator : AbstractValidator<CreatePaymentsDTO>
    {
        public CreatePaymentValidator() 
        {
            RuleFor(x => x.OrderID)
            .GreaterThan(0).WithMessage("Order ID must be greater than 0.");

            RuleFor(x => x.PaymentAmount)
                .GreaterThan(0).WithMessage("Payment amount must be greater than 0.");

            RuleFor(x => x.PaymentDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Payment date cannot be in the future.");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("Payment method is required.")
                .Length(2, 50).WithMessage("Payment method must be between 2 and 50 characters.");
        }
    }
}
