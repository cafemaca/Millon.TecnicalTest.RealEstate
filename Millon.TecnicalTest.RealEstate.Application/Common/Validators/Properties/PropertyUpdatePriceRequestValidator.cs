// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2025
//  ****************************************************************
//  <copyright file="PropertyUpdateRequestValidator.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using FluentValidation;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Properties;
using Millon.TecnicalTest.RealEstate.Domain.Common.Errors.Properties;
using Millon.TecnicalTest.RealEstate.Domain.Common.ModelConstants;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Validators.Properties
{
    public class PropertyUpdatePriceRequestValidator : AbstractValidator<PropertyUpdatePriceRequest>
    {
        public PropertyUpdatePriceRequestValidator()
        {
            RuleFor(x => x.Price).GreaterThan(0).WithMessage(PropertyErrors.ValidPrice(0).ErrorMessage).WithErrorCode(PropertyErrors.ValidPrice(0).ErrorCode);
        }
    }
}
