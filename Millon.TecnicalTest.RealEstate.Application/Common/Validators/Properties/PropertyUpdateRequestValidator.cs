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
    public class PropertyUpdateRequestValidator : AbstractValidator<PropertyUpdateRequest>
    {
        public PropertyUpdateRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(PropertyErrors.RequiredName.ErrorMessage).WithErrorCode(PropertyErrors.RequiredName.ErrorCode)
                .Length(ModelConstants.Common.MinNameLength, ModelConstants.Common.MaxNameLength).WithMessage(PropertyErrors.ValidName.ErrorMessage).WithErrorCode(PropertyErrors.ValidName.ErrorCode);

            RuleFor(x => x.Address).NotNull().NotEmpty().WithMessage(PropertyErrors.RequiredAdress.ErrorMessage).WithErrorCode(PropertyErrors.RequiredAdress.ErrorCode)
                .Length(PropertyModelConstants.Property.MinAddressLength, PropertyModelConstants.Property.MaxAddressLength).WithMessage(PropertyErrors.RequiredAdress.ErrorMessage).WithErrorCode(PropertyErrors.ValidAdress.ErrorCode);

            RuleFor(x => x.Price).GreaterThan(0).WithMessage(PropertyErrors.ValidPrice(0).ErrorMessage).WithErrorCode(PropertyErrors.ValidPrice(0).ErrorCode);

            RuleFor(x => x.CodeInternal).NotNull().NotEmpty().WithMessage(PropertyErrors.RequiredCodeInternal.ErrorMessage).WithErrorCode(PropertyErrors.RequiredCodeInternal.ErrorCode)
                .Length(PropertyModelConstants.Property.MinCodeInternalLength, PropertyModelConstants.Property.MaxCodeInternalLength).WithMessage(PropertyErrors.RequiredCodeInternal.ErrorMessage).WithErrorCode(PropertyErrors.ValidCodeInternal.ErrorCode);
        }
    }
}
