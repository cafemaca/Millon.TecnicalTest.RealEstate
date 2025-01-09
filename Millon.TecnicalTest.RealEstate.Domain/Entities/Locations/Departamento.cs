// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           : Carlos Fernando Malagón Cano
//  Created          : 11/10/2024 3:41:11 AM
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11/10/2024 3:41:11 AM
//  ****************************************************************
//  <copyright file="Departamento.cs" company="CAFEMACA Inc. Colombia">
//      CAFEMACA Inc. Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Common.Domain.Interfaces;

namespace Millon.TecnicalTest.RealEstate.Domain.Entities.Location
{
    /// <summary>
    /// Clase que identifica a un determinado Departamento.
    /// </summary>
    public sealed class Departamento : Entity<string>, IAuditableEntity
    {
        public string Name { get; set; } = string.Empty;

        public string PaisId { get; set; }
        public Pais Pais { get; set; }

        public ICollection<Municipio> Municipios { get; set; }

        #region Auditable Entity
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }
        #endregion
    }
}
