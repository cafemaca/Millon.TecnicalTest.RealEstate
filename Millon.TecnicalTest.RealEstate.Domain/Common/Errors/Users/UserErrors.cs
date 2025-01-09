// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 08-23-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 08-23-2024
//  ****************************************************************
//  <copyright file="UsuarioErrors.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Domain.Common.ModelConstants;

namespace Millon.TecnicalTest.RealEstate.Domain.Common.Errors.Users
{
    public class UserErrors
    {
        #region Bussines Validator Errors
        public static readonly DomainError RequiredId = new("Usuario.RequiredId", "Required Id");
        public static readonly DomainError RequiredName = new("Usuario.RequiredName", "Required Name");
        public static readonly DomainError RequiredPhone = new("Usuario.RequiredPhone", "Required Phone");
        public static readonly DomainError RequiredAdress = new("Usuario.RequiredAdress", "Required Adress");
        public static readonly DomainError ValidId = new("Usuario.ValidId", $"Id length should between {UserModelConstants.Usuario.MinIdLength} to {UserModelConstants.Usuario.MaxIdLength}");
        public static readonly DomainError ValidName = new("Usuario.ValidName", $"Name length should between {UserModelConstants.Usuario.MinNameLength} to {UserModelConstants.Usuario.MaxNameLength}");
        public static readonly DomainError ValidAdress = new("Usuario.ValidAdress", $"Adress length should between {UserModelConstants.Direccion.MinNameLength} to {UserModelConstants.Direccion.MaxNameLength}");
        public static readonly DomainError RequiredIdMunicipio = new("Usuario.RequiredIdMunicipio", "Required Id Municipio");
        public static readonly DomainError ValidIdMunicipio = new("Usuario.ValidIdMunicipio", "Id Municipio length should between 2 to 6");
        #endregion

        #region Bussines Errors
        public static DomainError NotFound(string id) => new("Usuario.NotFound", $"The Usuario with Id '{id}' was not found");
        #endregion
    }
}
