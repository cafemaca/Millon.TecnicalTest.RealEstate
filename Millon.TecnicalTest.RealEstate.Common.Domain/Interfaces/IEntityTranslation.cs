// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-07-2024 
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-07-2024
//  ****************************************************************
//  <copyright file="IEntityTranslation.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

namespace Millon.TecnicalTest.RealEstate.Common.Domain.Interfaces
{
    /// <summary>
    // Defines interface for entity translation type.
    /// </summary>
    public interface IEntityTranslation
    {
        string Language { get; set; }
    }

    public interface IEntityTranslation<TEntity> : IEntityTranslation<TEntity, int>
    {
    }

    public interface IEntityTranslation<TEntity, TPrimaryKeyOfMultiLingualEntity> : IEntityTranslation
    {
        TEntity Core { get; set; }
        TPrimaryKeyOfMultiLingualEntity CoreId { get; set; }
    }
}
