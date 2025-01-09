// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="DepartamentoRequestValidator.cs"
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
    public class DepartamentoCreateRequestValidator : AbstractValidator<DepartamentoCreateRequest>
    {
        public DepartamentoCreateRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage(DepartamentoErrors.RequiredId.ErrorMessage).WithErrorCode(DepartamentoErrors.RequiredId.ErrorCode)
                .Length(LocationModelConstants.Departamento.MinIdLength, LocationModelConstants.Departamento.MaxIdLength).WithMessage(DepartamentoErrors.ValidId.ErrorMessage).WithErrorCode(DepartamentoErrors.ValidId.ErrorCode);

            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(DepartamentoErrors.RequiredName.ErrorMessage).WithErrorCode(DepartamentoErrors.RequiredName.ErrorCode)
                .Length(ModelConstants.Common.MinNameLength, ModelConstants.Common.MaxNameLength).WithMessage(DepartamentoErrors.ValidName.ErrorMessage).WithErrorCode(DepartamentoErrors.ValidName.ErrorCode);

            RuleFor(x => x.PaisId).NotNull().NotEmpty().WithMessage(DepartamentoErrors.RequiredPaisId.ErrorMessage).WithErrorCode(DepartamentoErrors.RequiredPaisId.ErrorCode)
                .Length(LocationModelConstants.Pais.MinIdLength, LocationModelConstants.Pais.MaxIdLength).WithMessage(DepartamentoErrors.ValidPaisId.ErrorMessage).WithErrorCode(DepartamentoErrors.ValidPaisId.ErrorCode);
        }
    }
}
