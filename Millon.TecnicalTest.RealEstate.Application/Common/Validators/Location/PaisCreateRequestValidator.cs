// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-140-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="PaisRequestValidator.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using FluentValidation;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Location;
using Millon.TecnicalTest.RealEstate.Domain.Common.Errors.Locations;
using Millon.TecnicalTest.RealEstate.Domain.Common.ModelConstants;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Validators.Location
{
    public class PaisCreateRequestValidator : AbstractValidator<PaisCreateRequest>
    {
        public PaisCreateRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage(PaisErrors.RequiredId.ErrorMessage).WithErrorCode(PaisErrors.RequiredId.ErrorCode)
                .Length(LocationModelConstants.Pais.MinIdLength, LocationModelConstants.Pais.MaxIdLength).WithMessage(PaisErrors.ValidId.ErrorMessage).WithErrorCode(PaisErrors.ValidId.ErrorCode);
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(PaisErrors.RequiredName.ErrorMessage).WithErrorCode(PaisErrors.RequiredName.ErrorCode)
                .Length(ModelConstants.Common.MinNameLength, ModelConstants.Common.MaxNameLength).WithMessage(PaisErrors.ValidName.ErrorMessage).WithErrorCode(PaisErrors.ValidName.ErrorCode);
        }
    }
}
