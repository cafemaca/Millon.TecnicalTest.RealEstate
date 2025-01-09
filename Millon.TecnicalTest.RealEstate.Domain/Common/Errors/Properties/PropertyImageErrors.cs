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
    public class PropertyImageErrors
    {
        #region Bussines Validator Errors
        public static readonly DomainError RequiredId = new("PropertyImage.RequiredId", "Required Id");
        public static readonly DomainError RequiredFile = new("PropertyImage.RequiredFile", "Required File");
        public static readonly DomainError ValidFile= new("PropertyImage.ValidFile", $"File length should between {PropertyModelConstants.PropertyImage.MinFileLength} to {PropertyModelConstants.PropertyImage.MaxFileLength}");
        #endregion

        #region Bussines Errors
        public static DomainError NotFound(string id) => new("PropertyImage.NotFound", $"The Property with Id '{id}' was not found");
        #endregion
    }
}
