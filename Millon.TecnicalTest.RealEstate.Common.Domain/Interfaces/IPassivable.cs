// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-07-2024 
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-07-2024
//  ****************************************************************
//  <copyright file="IPassivable.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

namespace Millon.TecnicalTest.RealEstate.Common.Domain.Interfaces
{
    /// <summary>
    /// Interface usada para definir si una entidad es Activa/Inactiva.
    /// </summary>
    public interface IPassivable
    {
        /// <summary>
        /// <return>True: La entidad es activa. False: La entidad no es activa.</return>
        /// </summary>
        bool IsActive { get; set; }
    }
}
