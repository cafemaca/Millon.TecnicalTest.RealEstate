// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 08-23-2024 
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 08-23-2024
//  ****************************************************************
//  <copyright file="IAuditableEntity.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

namespace Millon.TecnicalTest.RealEstate.Common.Domain.Interfaces
{
    public interface IAuditableEntity
    {
        DateTime CreatedAtUtc { get; set; }

        DateTime? UpdatedAtUtc { get; set; }

        string CreatedBy { get; set; }

        string? UpdatedBy { get; set; }
    }
}
