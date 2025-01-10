// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Data
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-10-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-10-2025
//  ****************************************************************
//  <copyright file="CachedMemoryPropertyRepository.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories.Properties;
using Millon.TecnicalTest.RealEstate.Common.Application.Interfaces;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Data.Common.Options;
using Millon.TecnicalTest.RealEstate.Data.Context;
using Millon.TecnicalTest.RealEstate.Data.Repositories.Properties;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Properties;

namespace Millon.TecnicalTest.RealEstate.Data.Cache.Properties
{
    public class CachedMemoryPropertyRepository : GenericCacheRepository<Property, int, RealEstateDbContext>, IPropertyRepository
    {
        PropertyRepository _decorated;
        IDistributedCache _memoryCache;

        public CachedMemoryPropertyRepository(PropertyRepository decorated, IDistributedCache memoryCache, IOptions<CacheOptions> options) : base(decorated, memoryCache, options)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
        }

        public async Task<PagedList<Property>> GetAllAsync(ISpecificationQuery<Property> specification, int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            return await _decorated.GetAllAsync(specification, pageIndex, pageSize, cancellationToken);
        }
    }

}
