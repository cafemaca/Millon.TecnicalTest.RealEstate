// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="UsuarioRequestValidator.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using FluentValidation;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Users;
using Millon.TecnicalTest.RealEstate.Domain.Common.Errors.Users;
using Millon.TecnicalTest.RealEstate.Domain.Common.ModelConstants;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Validators.Users
{
    public class UserCreateRequestValidator : AbstractValidator<UserCreateRequest>
    {
        public UserCreateRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage(UserErrors.RequiredId.ErrorMessage).WithErrorCode(UserErrors.RequiredId.ErrorCode)
                .Length(UserModelConstants.Usuario.MinIdLength, UserModelConstants.Usuario.MaxIdLength).WithMessage(UserErrors.ValidId.ErrorMessage).WithErrorCode(UserErrors.ValidId.ErrorCode);

            RuleFor(x => x.Nombre).NotNull().NotEmpty().WithMessage(UserErrors.RequiredName.ErrorMessage).WithErrorCode(UserErrors.RequiredName.ErrorCode)
                .Length(ModelConstants.Common.MinNameLength, ModelConstants.Common.MaxNameLength).WithMessage(UserErrors.ValidName.ErrorMessage).WithErrorCode(UserErrors.ValidName.ErrorCode);

            RuleFor(x => x.Telefono).NotNull().NotEmpty().WithMessage(UserErrors.RequiredPhone.ErrorMessage).WithErrorCode(UserErrors.RequiredPhone.ErrorCode)
                .Length(UserModelConstants.Usuario.MinPhoneLength, UserModelConstants.Usuario.MaxPhoneLength).WithMessage(UserErrors.ValidName.ErrorMessage).WithErrorCode(UserErrors.ValidName.ErrorCode);

            RuleFor(x => x.Direccion).NotNull().NotEmpty().WithMessage(UserErrors.RequiredAdress.ErrorMessage).WithErrorCode(UserErrors.RequiredAdress.ErrorCode);
            RuleFor(x => x.Direccion.DireccionName).NotEmpty().WithMessage(UserErrors.RequiredAdress.ErrorMessage).WithErrorCode(UserErrors.RequiredAdress.ErrorCode)
                .MinimumLength(UserModelConstants.Direccion.MinNameLength).WithMessage($"Price currency must have at most {UserErrors.ValidAdress} characters.")
                .MaximumLength(UserModelConstants.Direccion.MaxNameLength).WithMessage($"Price currency must have at most {UserErrors.ValidAdress} characters.");
        }
    }
}
