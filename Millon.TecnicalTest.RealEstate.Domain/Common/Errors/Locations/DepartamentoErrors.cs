// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 08-23-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 08-23-2024
//  ****************************************************************
//  <copyright file="DepartamentoErrors.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Domain.Common.ModelConstants;

namespace Millon.TecnicalTest.RealEstate.Domain.Common.Errors.Locations
{
    public class DepartamentoErrors
    {
        #region Bussines Validator Errors
        public static readonly DomainError RequiredId = new("Departamento.RequiredId", "Required Id");
        public static readonly DomainError RequiredName = new("Departamento.RequiredName", "Required Name");
        public static readonly DomainError ValidId = new("Departamentp.ValidId", $"Id length must be between {LocationModelConstants.Departamento.MinIdLength} and {LocationModelConstants.Departamento.MaxIdLength} characters.");
        public static readonly DomainError ValidName = new("Departamento.ValidName", $"Name length must be between {ModelConstants.ModelConstants.Common.MinNameLength} to {ModelConstants.ModelConstants.Common.MaxNameLength}");
        public static readonly DomainError RequiredPaisId = new("Departamento.RequiredPaisId", "Required Id Pais");
        public static readonly DomainError ValidPaisId = new("Departamento.ValidPaisId", $"Id Pais length must be between {LocationModelConstants.Pais.MinIdLength} to {LocationModelConstants.Pais.MaxIdLength}");
        #endregion

        #region Bussines Errors
        public static DomainError NotFound(string id) => new("Departamento.NotFound", $"The Departamento with Id '{id}' was not found");
        #endregion
    }
}
