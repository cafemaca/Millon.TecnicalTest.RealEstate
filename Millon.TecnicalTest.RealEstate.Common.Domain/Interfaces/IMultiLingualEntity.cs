// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-07-2024 
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-07-2024
//  ****************************************************************
//  <copyright file="IMultiLingualEntity.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

namespace Millon.TecnicalTest.RealEstate.Common.Domain.Interfaces
{
    public interface IMultiLingualEntity<TTranslation> where TTranslation : class, IEntityTranslation
    {
        ICollection<TTranslation> Translations { get; set; }
    }
}
