// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-09-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-09-2025
//  ****************************************************************
//  <copyright file="DepartamentoRequest.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using Millon.TecnicalTest.RealEstate.Common.Application.SpecificationQueries;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Owners;
using System.Linq.Expressions;

namespace Millon.TecnicalTest.RealEstate.Application.Common.SpecificationQueries.Owners
{
    public class OwnerSpecificationQuery : BaseSpecificationQuery<Owner>
    {
        public OwnerSpecificationQuery() : base()
        {

        }

        public OwnerSpecificationQuery(int id) : base()
        {

        }

        public OwnerSpecificationQuery(Expression<Func<Owner, bool>> criteria, List<SpecificationSort<Owner>> orderby) : base(criteria)
        {
            OrderBy = orderby;
        }
    }
}
