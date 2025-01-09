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


using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories.Owners;
using Millon.TecnicalTest.RealEstate.Common.Application.Interfaces;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Data.Common.Options;
using Millon.TecnicalTest.RealEstate.Data.Context;
using Millon.TecnicalTest.RealEstate.Data.Repositories.Owners;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Owners;

namespace Millon.TecnicalTest.RealEstate.Data.Cache.Owners
{
    public class CachedMemoryOwnerRepository : GenericCacheRepository<Owner, int, RealEstateDbContext>, IOwnerRepository
    {
        OwnerRepository _decorated;
        IDistributedCache _memoryCache;

        public CachedMemoryOwnerRepository(OwnerRepository decorated, IDistributedCache memoryCache, IOptions<CacheOptions> options) : base(decorated, memoryCache, options)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
        }

        public async Task<PagedList<Owner>> GetAllAsync(ISpecificationQuery<Owner> specification, int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            return await _decorated.GetAllAsync(specification, pageIndex, pageSize, cancellationToken);
        }
    }

}
