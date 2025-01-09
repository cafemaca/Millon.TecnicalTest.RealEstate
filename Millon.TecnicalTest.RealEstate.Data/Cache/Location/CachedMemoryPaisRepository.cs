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

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories.Location;
using Millon.TecnicalTest.RealEstate.Common.Application.Interfaces;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Data.Common.Options;
using Millon.TecnicalTest.RealEstate.Data.Context;
using Millon.TecnicalTest.RealEstate.Data.Repositories.Location;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Location;

namespace Millon.TecnicalTest.RealEstate.Data.Cache.Location
{
    public class CachedMemoryPaisRepository : GenericCacheRepository<Pais, string, CafemacaDbContext>, IPaisRepository
    {
        PaisRepository _decorated;
        IDistributedCache _memoryCache;

        public CachedMemoryPaisRepository(PaisRepository decorated, IDistributedCache memoryCache, IOptions<CacheOptions> options) : base(decorated, memoryCache, options)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
        }

        public async Task<PagedList<Pais>> GetAllAsync(ISpecificationQuery<Pais> specification, int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            return await _decorated.GetAllAsync(specification, pageIndex, pageSize, cancellationToken);
        }
    }

}
