// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-09-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-09-2025
//  ****************************************************************
//  <copyright file="PropertyTrace.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Domain.Common.ModelConstants;

namespace Millon.TecnicalTest.RealEstate.Domain.Common.Errors.Properties
{
    public class PropertyTraceErrors
    {
        #region Bussines Validator Errors
        public static readonly DomainError RequiredId = new("PropertyTrace.RequiredId", "Required Id");
        public static readonly DomainError RequiredName = new("PropertyTrace.RequiredName", "Required Name");
        public static readonly DomainError ValidName = new("PropertyTrace.ValidName", $"Name length should between {PropertyModelConstants.PropertyTrace.MinNameLength} to {PropertyModelConstants.PropertyTrace.MaxNameLength}");
        #endregion

        #region Bussines Errors
        public static DomainError NotFound(string id) => new("PropertyTrace.NotFound", $"The Property with Id '{id}' was not found");
        #endregion
    }
}
