// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           : MSI
//  Created          : 1/9/2025 9:35:32 AM
//
//  Last Modified By : MSI
//  Last Modified On : 1/9/2025 9:35:32 AM
//  ****************************************************************
//  <copyright file="PropertyImage.cs" company="CAFEMACA Inc. Colombia">
//      CAFEMACA Inc. Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Common.Domain.Interfaces;

namespace Millon.TecnicalTest.RealEstate.Domain.Entities.Properties
{
    /// <summary>
    /// Class that represents an image of a certain property.
    /// </summary>
    public class PropertyImage : Entity<int>, IAuditableEntity
    {
        public string File { get; set; } = string.Empty;
        public bool Enabled { get; set; }
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
