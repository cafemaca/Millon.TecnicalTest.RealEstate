// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 09-19-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 10-09-2024
//  ****************************************************************
//  <copyright file="AuditTrail.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Domain.Common.Enums;

namespace Millon.TecnicalTest.RealEstate.Domain.Entities.Audit
{
    public class AuditTrail : Entity<Guid>
    {
        public Guid? UserId { get; set; }

        //TODO: Security.
        //Here we have a reference to a User entity. Depending on your application needs, you may have this reference or not.
        //public User? User { get; set; }

        public TrailType TrailType { get; set; }

        public DateTime DateUtc { get; set; }

        public string EntityName { get; set; }

        public string? PrimaryKey { get; set; }

        public Dictionary<string, object?> OldValues { get; set; } = [];

        public Dictionary<string, object?> NewValues { get; set; } = [];

        public List<string> ChangedColumns { get; set; } = [];
    }
}
