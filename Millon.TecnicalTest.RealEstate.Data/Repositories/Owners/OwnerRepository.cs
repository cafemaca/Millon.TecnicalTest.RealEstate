// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Data
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-09-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-09-2025
//  ****************************************************************
//  <copyright file="ApplicationDbContext.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories.Owners;
using Millon.TecnicalTest.RealEstate.Application.Common.SpecificationQueries;
using Millon.TecnicalTest.RealEstate.Common.Application.Interfaces;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Common.Data.Repositories;
using Millon.TecnicalTest.RealEstate.Data.Context;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Owners;

namespace Millon.TecnicalTest.RealEstate.Data.Repositories.Owners
{
    public class OwnerRepository : EntityRepository<Owner, int, RealEstateDbContext>, IOwnerRepository
    {
        public OwnerRepository(RealEstateDbContext context) : base(context)
        {
        }

        public async Task<PagedList<Owner>> GetAllAsync(ISpecificationQuery<Owner> specification, int pageIndex, int pageSize, CancellationToken cancellationToken)
        {

            return await PagedList<Owner>.CreateAsync(SpecificationQueryBuilder.GetQuery(_dbSet, specification).AsQueryable<Owner>(), pageIndex, pageSize);
        }
    }
}
