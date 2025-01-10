// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-09-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-09-2025
//  ****************************************************************
//  <copyright file="PropertyErrors.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Domain.Common.ModelConstants;

namespace Millon.TecnicalTest.RealEstate.Domain.Common.Errors.Properties
{
    public class PropertyErrors
    {
        #region Bussines Validator Errors
        public static readonly DomainError RequiredId = new("Property.RequiredId", "Required Id");
        public static readonly DomainError RequiredName = new("Property.RequiredName", "Required Name");
        public static readonly DomainError RequiredAdress = new("Property.RequiredAdress", "Required Adress");
        public static readonly DomainError RequiredPhoto = new("Property.RequiredPhone", "Required Photo");
        public static readonly DomainError ValidName = new("Property.ValidName", $"Name length should between {PropertyModelConstants.Property.MinNameLength} to {PropertyModelConstants.Property.MaxNameLength}");
        public static readonly DomainError ValidAdress = new("Property.ValidAdress", $"Adress length should between {PropertyModelConstants.Property.MinAddressLength} to {PropertyModelConstants.Property.MaxAddressLength}");
        public static readonly DomainError RequiredCodeInternal= new("Property.RequiredCodeInternal", "Required Code Internal");
        public static readonly DomainError ValidCodeInternal = new("Property.ValidCodeInternal", $"Conde Internal length should between {PropertyModelConstants.Property.MinCodeInternalLength} to {PropertyModelConstants.Property.MaxCodeInternalLength}");
        #endregion

        #region Bussines Errors
        public static DomainError ValidPrice(double price) => new("Property.Price", $"The property price must be greater than {price}");
        public static DomainError NotFound(int id) => new("Property.NotFound", $"The Property with Id '{id}' was not found");
        #endregion
    }
}
