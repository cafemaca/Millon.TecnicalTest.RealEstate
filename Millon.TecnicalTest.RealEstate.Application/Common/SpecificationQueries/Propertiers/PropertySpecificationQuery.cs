// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-10-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-10-2025
//  ****************************************************************
//  <copyright file="DepartamentoRequest.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using Millon.TecnicalTest.RealEstate.Common.Application.SpecificationQueries;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Owners;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Properties;
using System.Linq.Expressions;

namespace Millon.TecnicalTest.RealEstate.Application.Common.SpecificationQueries.Properties
{
    public class PropertySpecificationQuery : BaseSpecificationQuery<Property>
    {
        public PropertySpecificationQuery() : base()
        {

        }

        public PropertySpecificationQuery(int id) : base(b => b.Id == id)
        {

        }

        public PropertySpecificationQuery(Expression<Func<Property, bool>> criteria, List<SpecificationSort<Property>> orderby) : base(criteria)
        {
            OrderBy = orderby;
        }
    }

}
