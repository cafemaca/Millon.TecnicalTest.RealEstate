// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-09-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-09-2025
//  ****************************************************************
//  <copyright file="OwnerErrors.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Domain.Common.ModelConstants;

namespace Millon.TecnicalTest.RealEstate.Domain.Common.Errors.Owners
{
    public class OwnerErrors
    {
        #region Bussines Validator Errors
        public static readonly DomainError RequiredId = new("Owner.RequiredId", "Required Id");
        public static readonly DomainError RequiredName = new("Owner.RequiredName", "Required Name");
        public static readonly DomainError RequiredAdress = new("Owner.RequiredAdress", "Required Adress");
        public static readonly DomainError RequiredPhoto = new("Owner.RequiredPhone", "Required Photo");
        public static readonly DomainError ValidName = new("Owner.ValidName", $"Name length should between {OwnerModelConstants.Owner.MinNameLength} to {OwnerModelConstants.Owner.MaxNameLength}");
        public static readonly DomainError ValidAdress = new("Owner.ValidAdress", $"Adress length should between {OwnerModelConstants.Owner.MinAddressLength} to {OwnerModelConstants.Owner.MaxAddressLength}");
        public static readonly DomainError ValidPhoto = new("Owner.ValidPhoto", $"Name length should between {OwnerModelConstants.Owner.MinPhotoLength} to {OwnerModelConstants.Owner.MaxPhotoLength}");
        public static readonly DomainError RequiredBirthday = new("Owner.RequiredBirthday", "Required Birth Day");
        #endregion

        #region Bussines Errors
        public static DomainError ValidBirthday(DateOnly birthday)
        {
            return new("Owner.ValidBirthday", $"The date of birth must be greater than or equal to {birthday}");
        }
        public static DomainError NotFound(int id) => new("Owner.NotFound", $"The Owner with Id '{id}' was not found");
        #endregion
    }
}
