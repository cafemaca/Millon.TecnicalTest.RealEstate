// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-09-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-09-2025
//  ****************************************************************
//  <copyright file="PropertyModelConstants.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


namespace Millon.TecnicalTest.RealEstate.Domain.Common.ModelConstants
{
    /// <summary>
    /// Class that contains the constant definitions of the Properties domain
    /// </summary>
    public class PropertyModelConstants
    {
        /// <summary>
        /// Class that contains the constant definitions of the Property entity.
        /// </summary>
        public class Property
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 100;
            public const int MinAddressLength = 5;
            public const int MaxAddressLength = 100;
            public const int MinCodeInternalLength = 5;
            public const int MaxCodeInternalLength = 100;
        }

        /// <summary>
        /// Class that contains the constant definitions of the PropertyTrace entity
        /// </summary>
        public class PropertyTrace
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 100;
        }

        /// <summary>
        /// Class that contains the constant definitions of the PropertyImage entity
        /// </summary>
        public class PropertyImage
        {
            public const int MinFileLength = 2;
            public const int MaxFileLength = 100;
        }
    }
}
