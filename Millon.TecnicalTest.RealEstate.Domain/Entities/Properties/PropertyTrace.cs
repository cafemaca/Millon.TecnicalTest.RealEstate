// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           : MSI
//  Created          : 1/9/2025 9:30:07 AM
//
//  Last Modified By : MSI
//  Last Modified On : 1/9/2025 9:30:07 AM
//  ****************************************************************
//  <copyright file="PropertyTrace.cs" company="CAFEMACA Inc. Colombia">
//      CAFEMACA Inc. Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Common.Domain.Interfaces;

namespace Millon.TecnicalTest.RealEstate.Domain.Entities.Properties
{
    /// <summary>
    /// Class that represents Tracking a property.
    /// </summary>
    public class PropertyTrace : Entity<int>, IAuditableEntity
    {
        public DateOnly DateSale { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Value { get; set; }
        public double Tax { get; set; }

        public int IdProperty { get; set; }
        public Property Property { get; set; }

        #region Auditable Entity
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }
        #endregion
    }
}
