// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           : Carlos Fernando Malagón Cano
//  Created          : 1/9/2025 8:40:48 AM
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 1/9/2025 8:40:48 AM
//  ****************************************************************
//  <copyright file="Owner.cs" company="CAFEMACA Inc. Colombia">
//      CAFEMACA Inc. Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Common.Domain.Interfaces;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Properties;

namespace Millon.TecnicalTest.RealEstate.Domain.Entities.Owners
{
    /// <summary>
    /// Class that describes the Owner entity.
    /// </summary>
    public class Owner : Entity<int>, IAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }

        public ICollection<Property> Properties { get; set; }

        #region Auditable Entity
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }
        #endregion
    }
}
