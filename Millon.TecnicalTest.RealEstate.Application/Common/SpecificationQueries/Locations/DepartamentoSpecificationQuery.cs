// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="DepartamentoSpecificationQuery.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using System.Linq.Expressions;
using Millon.TecnicalTest.RealEstate.Common.Application.SpecificationQueries;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Location;

namespace Millon.TecnicalTest.RealEstate.Application.Common.SpecificationQueries.Location
{
    public class DepartamentoSpecificationQuery : BaseSpecificationQuery<Departamento>
    {
        public DepartamentoSpecificationQuery() : base()
        {
            AddInclude(b => b.Pais);
        }
        public DepartamentoSpecificationQuery(string Id)
            : base(b => b.Id == Id)
        {
            AddInclude(b => b.Pais);
        }

        public DepartamentoSpecificationQuery(Expression<Func<Departamento, bool>> criteria, List<SpecificationSort<Departamento>> orderby) : base(criteria)
        {
            AddInclude(b => b.Pais);
            OrderBy = orderby;
        }
    }
}
