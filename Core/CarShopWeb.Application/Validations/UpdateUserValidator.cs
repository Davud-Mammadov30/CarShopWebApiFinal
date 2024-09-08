using CarShopWeb.Application.DTOs.UsersDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Validations
{
    public class UpdateUserValidator : AbstractValidator<UserUpdateDTO>
    {
        public UpdateUserValidator() 
        {
            RuleFor(x => x.UserID)
            .NotEmpty().WithMessage("User ID is required.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");
        }
    }
}
