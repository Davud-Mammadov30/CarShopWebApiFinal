using CarShopWeb.Application.DTOs.FeaturesDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Validations.FeaturesValidator
{
    public class UpdateFeatureValidator : AbstractValidator<UpdateFeaturesDTO>
    {
        public UpdateFeatureValidator() 
        {
            RuleFor(x => x.FutureType)
            .NotEmpty().WithMessage("Feature type is required.")
            .Length(2, 50).WithMessage("Feature type must be between 2 and 50 characters.");

            RuleFor(x => x.FutureName)
                .NotEmpty().WithMessage("Feature name is required.")
                .Length(2, 100).WithMessage("Feature name must be between 2 and 100 characters.");

            RuleFor(x => x.AdditionalPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Additional price must be greater than or equal to 0.");
        }
    }
}
