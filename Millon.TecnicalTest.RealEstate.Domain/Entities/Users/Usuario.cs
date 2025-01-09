// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           : CArlos Fernando Malagón Cano
//  Created          : 11/10/2024 3:45:33 AM
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11/10/2024 3:45:33 AM
//  ****************************************************************
//  <copyright file="Usuario.cs" company="CAFEMACA Inc. Colombia">
//      CAFEMACA Inc. Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Common.Domain.Interfaces;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Users;

namespace Millon.TecnicalTest.RealEstate.Domain.Entities.Users
{
    /// <summary>
    /// Clase que identifica a un determinado Usuario.
    /// </summary>
    public sealed class Usuario : AggregateRoot<string>, IAuditableEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;

        public Direccion Direccion { get; set; }

        #region Auditable Entity
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }
        #endregion
    }
}
