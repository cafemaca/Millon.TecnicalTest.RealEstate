// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="UsuarioSpecificationQuery.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using System.Linq.Expressions;
using Millon.TecnicalTest.RealEstate.Common.Application.SpecificationQueries;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Users;

namespace Millon.TecnicalTest.RealEstate.Application.Common.SpecificationQueries.Users
{
    public class UserSpecificationQuery : BaseSpecificationQuery<Usuario>
    {
        public UserSpecificationQuery() : base()
        {
            AddInclude(u => u.Direccion.Municipio.Departamento.Pais);
        }

        public UserSpecificationQuery(string id) : base()
        {
            AddInclude(u => u.Direccion.Municipio.Departamento.Pais);
        }

        public UserSpecificationQuery(Expression<Func<Usuario, bool>> criteria, List<SpecificationSort<Usuario>> orderby) : base(criteria)
        {
            AddInclude(u => u.Direccion.Municipio.Departamento.Pais);
            OrderBy = orderby;
        }
    }
}
