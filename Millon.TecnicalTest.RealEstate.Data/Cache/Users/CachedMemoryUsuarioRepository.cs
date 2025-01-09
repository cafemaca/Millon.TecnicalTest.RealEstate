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
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories.Users;
using Millon.TecnicalTest.RealEstate.Common.Application.Interfaces;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Data.Common.Options;
using Millon.TecnicalTest.RealEstate.Data.Context;
using Millon.TecnicalTest.RealEstate.Data.Repositories.Users;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Users;

namespace Millon.TecnicalTest.RealEstate.Data.Cache.User
{
    public class CachedMemoryUsuarioRepository : GenericCacheRepository<Usuario, string, RealEstateDbContext>, IUserRepository
    {
        UserRepository _decorated;
        IDistributedCache _memoryCache;

        public CachedMemoryUsuarioRepository(UserRepository decorated, IDistributedCache memoryCache, IOptions<CacheOptions> options) : base(decorated, memoryCache, options)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
        }

        public async Task<PagedList<Usuario>> GetAllAsync(ISpecificationQuery<Usuario> specification, int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            return await _decorated.GetAllAsync(specification, pageIndex, pageSize, cancellationToken);
        }
    }
}
