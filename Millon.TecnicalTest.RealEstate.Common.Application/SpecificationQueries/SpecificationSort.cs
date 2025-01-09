// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="DepartamentoRequest.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using System.Linq.Expressions;

namespace Millon.TecnicalTest.RealEstate.Common.Application.SpecificationQueries
{
    public class SpecificationSort<T>
    {
        public Expression<Func<T, object>> PropertySort { get; set; }
        public bool Desc { get; set; }

        public SpecificationSort(Expression<Func<T, object>> propertySort, bool desc)
        {
            PropertySort = propertySort;
            Desc = desc;

        }
    }

}
