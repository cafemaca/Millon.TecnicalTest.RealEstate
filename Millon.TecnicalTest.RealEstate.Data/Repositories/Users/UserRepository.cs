// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Data
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="ApplicationDbContext.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories.Users;
using Millon.TecnicalTest.RealEstate.Application.Common.SpecificationQueries;
using Millon.TecnicalTest.RealEstate.Common.Application.Interfaces;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Common.Data.Repositories;
using Millon.TecnicalTest.RealEstate.Data.Context;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Users;

namespace Millon.TecnicalTest.RealEstate.Data.Repositories.Users
{
    public class UserRepository : EntityRepository<Usuario, string, CafemacaDbContext>, IUserRepository
    {
        public UserRepository(CafemacaDbContext context) : base(context)
        {
        }

        public async Task<PagedList<Usuario>> GetAllAsync(ISpecificationQuery<Usuario> specification, int pageIndex, int pageSize, CancellationToken cancellationToken)
        {

            return await PagedList<Usuario>.CreateAsync(SpecificationQueryBuilder.GetQuery(_dbSet, specification).AsQueryable<Usuario>(), pageIndex, pageSize);
        }
    }
}
