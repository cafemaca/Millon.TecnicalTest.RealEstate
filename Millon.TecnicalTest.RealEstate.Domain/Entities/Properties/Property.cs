// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           : MSI
//  Created          : 1/9/2025 9:23:35 AM
//
//  Last Modified By : MSI
//  Last Modified On : 1/9/2025 9:23:35 AM
//  ****************************************************************
//  <copyright file="Property.cs" company="CAFEMACA Inc. Colombia">
//      CAFEMACA Inc. Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Common.Domain.Interfaces;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Owners;

namespace Millon.TecnicalTest.RealEstate.Domain.Entities.Properties
{
    /// <summary>
    /// Class that describes an entity Property.
    /// </summary>
    public class Property : Entity<int>, IAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Price { get; set; }
        public string CodeInternal { get; set; } = string.Empty;
        public int Year { get; set; }

        public int IdOwner { get; set; }
        public Owner Owner { get; set; }


        public ICollection<PropertyImage> Images { get; set; } = new List<PropertyImage>();
        public ICollection<PropertyTrace> Traces { get; set; }


        #region Auditable Entity
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }
        #endregion
    }
}
