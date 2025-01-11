// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-10-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-10-2025
//  ****************************************************************
//  <copyright file="PropertyCreateRequestValidator.cs"
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
    public class PropertyAddImageRequestValidator : AbstractValidator<PropertyImageCreateRequest>
    {
        public PropertyAddImageRequestValidator()
        {
            RuleFor(x => x.File).NotNull().NotEmpty().WithMessage(PropertyImageErrors.RequiredFile.ErrorMessage).WithErrorCode(PropertyImageErrors.RequiredFile.ErrorCode)
                .Length(PropertyModelConstants.PropertyImage.MinFileLength, PropertyModelConstants.PropertyImage.MaxFileLength).WithMessage(PropertyImageErrors.ValidFile.ErrorMessage).WithErrorCode(PropertyImageErrors.ValidFile.ErrorCode);
        }
    }
}
