// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 08-23-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 08-23-2024
//  ****************************************************************
//  <copyright file="PaisErrors.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Domain.Common.ModelConstants;

namespace Millon.TecnicalTest.RealEstate.Domain.Common.Errors.Locations
{
    public class PaisErrors
    {
        #region Bussines Validator Errors
        public static readonly DomainError RequiredId = new("Pais.RequiredId", "Required Id");
        public static readonly DomainError RequiredName = new("Pais.RequiredName", "Required Name");
        public static readonly DomainError ValidId = new("Pais.ValidId", $"Id length must be between {LocationModelConstants.Pais.MinIdLength} and {LocationModelConstants.Pais.MaxIdLength} characters.");
        public static readonly DomainError ValidName = new("Pais.ValidName", $"Name length must be between {ModelConstants.ModelConstants.Common.MinNameLength} to {ModelConstants.ModelConstants.Common.MaxNameLength}");
        #endregion

        #region Bussines Errors
        public static DomainError NotFound(string id) => new("Pais.NotFound", $"The Pais with Id '{id}' was not found");
        #endregion
    }
}
