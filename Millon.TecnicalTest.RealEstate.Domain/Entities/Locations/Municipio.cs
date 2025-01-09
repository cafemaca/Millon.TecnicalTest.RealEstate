﻿// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           : Carlos Fernando Malagón Cano
//  Created          : 11/10/2024 3:43:14 AM
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11/10/2024 3:43:14 AM
//  ****************************************************************
//  <copyright file="Municipio.cs" company="CAFEMACA Inc. Colombia">
//      CAFEMACA Inc. Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Common.Domain.Interfaces;

namespace Millon.TecnicalTest.RealEstate.Domain.Entities.Location
{
    /// <summary>
    /// Clase que identifica a un determinado Municipio.
    /// </summary>
    public sealed class Municipio : Entity<string>, IAuditableEntity
    {
        public string Name { get; set; } = string.Empty;

        public string DepartamentoId { get; set; }

        public Departamento Departamento { get; set; }

        #region Auditable Entity
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }
        #endregion
    }
}
