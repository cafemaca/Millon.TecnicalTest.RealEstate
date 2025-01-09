// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-09-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-09-2025
//  ****************************************************************
//  <copyright file="OwnerModelConstants.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


namespace Millon.TecnicalTest.RealEstate.Domain.Common.ModelConstants
{
    /// <summary>
    /// Class containing constant definitions for the Owner domain.
    /// </summary>
    public class OwnerModelConstants
    {
        public class Owner
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 100;
            public const int MinAddressLength = 5;
            public const int MaxAddressLength = 100;
            public const int MinPhotoLength = 5;
            public const int MaxPhotoLength = 100;
        }
    }
}
