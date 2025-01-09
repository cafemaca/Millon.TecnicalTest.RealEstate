// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 04-02-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 04-12-2024
//  ****************************************************************
//  <copyright file="MunicipioRequestValidator.cs"
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
    public class MunicipioCreateRequestValidator : AbstractValidator<MunicipioCreateRequest>
    {
        public MunicipioCreateRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage(MunicipioErrors.RequiredId.ErrorMessage).WithErrorCode(MunicipioErrors.RequiredId.ErrorCode)
                .Length(LocationModelConstants.Municipio.MinIdLength, LocationModelConstants.Municipio.MaxIdLength).WithMessage(MunicipioErrors.ValidId.ErrorMessage).WithErrorCode(MunicipioErrors.ValidId.ErrorCode);

            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(MunicipioErrors.RequiredName.ErrorMessage).WithErrorCode(MunicipioErrors.RequiredName.ErrorCode)
                .Length(ModelConstants.Common.MinNameLength, ModelConstants.Common.MaxNameLength).WithMessage(MunicipioErrors.ValidName.ErrorMessage).WithErrorCode(MunicipioErrors.ValidName.ErrorCode);

            RuleFor(x => x.DepartamentoId).NotNull().NotEmpty().WithMessage(MunicipioErrors.RequiredIdDepartamento.ErrorMessage).WithErrorCode(MunicipioErrors.RequiredIdDepartamento.ErrorCode)
                .Length(LocationModelConstants.Departamento.MinIdLength, LocationModelConstants.Departamento.MaxIdLength).WithMessage(MunicipioErrors.ValidIdDepartamento.ErrorMessage).WithErrorCode(MunicipioErrors.ValidIdDepartamento.ErrorCode);
        }
    }
}
