// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           : Carlos Fernando Malagón Camo
//  Created          : 11/10/2024 3:47:34 AM
//
//  Last Modified By : Carlos Fernando Malagón Camo
//  Last Modified On : 11/10/2024 3:47:34 AM
//  ****************************************************************
//  <copyright file="Direccion.cs" company="CAFEMACA Inc. Colombia">
//      CAFEMACA Inc. Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Location;

namespace Millon.TecnicalTest.RealEstate.Domain.Entities.Users
{
    /// <summary>
    /// Clase que identifica a un determinado Direccion.
    /// </summary>
    public sealed class Direccion : ValueObject
    {
        public string DireccionName { get; set; } = string.Empty;
        public string Municipioid { get; set; } = default;
        public Municipio Municipio { get; set; } = default;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DireccionName;
            yield return Municipioid;
        }
    }
}
