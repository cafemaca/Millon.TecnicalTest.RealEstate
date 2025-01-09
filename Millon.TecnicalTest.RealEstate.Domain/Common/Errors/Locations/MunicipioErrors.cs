// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 08-23-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 08-23-2024
//  ****************************************************************
//  <copyright file="MunicipioErrors.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Domain.Common.ModelConstants;

namespace Millon.TecnicalTest.RealEstate.Domain.Common.Errors.Locations
{
    public class MunicipioErrors
    {
        #region Bussines Validator Errors
        public static readonly DomainError RequiredId = new("Municipio.RequiredId", "Required Id");
        public static readonly DomainError RequiredName = new("Municipio.RequiredName", "Required Name");
        public static readonly DomainError ValidId = new("Municipio.ValidId", $"Id length must be between {LocationModelConstants.Municipio.MinIdLength} and {LocationModelConstants.Municipio.MaxIdLength} characters.");
        public static readonly DomainError ValidName = new("Municipio.ValidName", $"Name length must be between {ModelConstants.ModelConstants.Common.MinNameLength} to {ModelConstants.ModelConstants.Common.MaxNameLength}");
        public static readonly DomainError RequiredIdDepartamento = new("Municipio.RequiredIdDepartamento", "Required Id Departamento");
        public static readonly DomainError ValidIdDepartamento = new("Municipio.ValidIdDepartamento", $"Id Departamento length must be between {LocationModelConstants.Departamento.MinIdLength} to {LocationModelConstants.Departamento.MaxIdLength}");
        #endregion

        #region Bussines Errors
        public static DomainError NotFound(string id) => new("Municipio.NotFound", $"The Municipio with Id '{id}' was not found");
        #endregion
    }
}
