// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-09-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-09-2025
//  ****************************************************************
//  <copyright file="DepartamentoRequest.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using FluentValidation;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Owners;
using Millon.TecnicalTest.RealEstate.Domain.Common.Errors.Owners;
using Millon.TecnicalTest.RealEstate.Domain.Common.ModelConstants;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Validators.Owners
{
    public class OwnerCreateRequestValidator : AbstractValidator<OwnerCreateRequest>
    {
        public OwnerCreateRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(OwnerErrors.RequiredName.ErrorMessage).WithErrorCode(OwnerErrors.RequiredName.ErrorCode)
                .Length(ModelConstants.Common.MinNameLength, ModelConstants.Common.MaxNameLength).WithMessage(OwnerErrors.ValidName.ErrorMessage).WithErrorCode(OwnerErrors.ValidName.ErrorCode);

            RuleFor(x => x.Address).NotNull().NotEmpty().WithMessage(OwnerErrors.RequiredAdress.ErrorMessage).WithErrorCode(OwnerErrors.RequiredAdress.ErrorCode)
                .Length(OwnerModelConstants.Owner.MinAddressLength, OwnerModelConstants.Owner.MaxAddressLength).WithMessage(OwnerErrors.RequiredAdress.ErrorMessage).WithErrorCode(OwnerErrors.ValidAdress.ErrorCode);

            RuleFor(x => x.Photo).NotNull().NotEmpty().WithMessage(OwnerErrors.RequiredPhoto.ErrorMessage).WithErrorCode(OwnerErrors.RequiredPhoto.ErrorCode)
                .Length(OwnerModelConstants.Owner.MinPhotoLength, OwnerModelConstants.Owner.MaxPhotoLength).WithMessage(OwnerErrors.RequiredPhoto.ErrorMessage).WithErrorCode(OwnerErrors.ValidPhoto.ErrorCode);

            RuleFor(x => x.Birthday).GreaterThanOrEqualTo(new DateOnly(1900,1,1)).WithMessage(OwnerErrors.ValidBirthday(new DateOnly(1900, 1, 1)).ErrorMessage).WithErrorCode(OwnerErrors.ValidBirthday(new DateOnly(1900, 1, 1)).ErrorCode);
        }
    }
}
