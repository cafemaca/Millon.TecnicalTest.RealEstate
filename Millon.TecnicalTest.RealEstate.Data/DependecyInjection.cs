// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Data
//  Author           :  cmalagoncmalagon
//  Created          : 01-09-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-09-2025
//  ****************************************************************
//  <copyright file="DependecyInjection.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories.Location;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories.Owners;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories.Properties;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories.Users;
using Millon.TecnicalTest.RealEstate.Common.Application.Interfaces;
using Millon.TecnicalTest.RealEstate.Data.Cache.Location;
using Millon.TecnicalTest.RealEstate.Data.Cache.Owners;
using Millon.TecnicalTest.RealEstate.Data.Cache.Properties;
using Millon.TecnicalTest.RealEstate.Data.Cache.User;
using Millon.TecnicalTest.RealEstate.Data.Repositories;
using Millon.TecnicalTest.RealEstate.Data.Repositories.Audit;
using Millon.TecnicalTest.RealEstate.Data.Repositories.Location;
using Millon.TecnicalTest.RealEstate.Data.Repositories.Owners;
using Millon.TecnicalTest.RealEstate.Data.Repositories.Properties;
using Millon.TecnicalTest.RealEstate.Data.Repositories.Users;

namespace Millon.TecnicalTest.RealEstate.Data
{
    /// <summary>
    /// 
    /// </summary>
    public static class DependecyInjection
    {
        public static IServiceCollection AddDataRepositories(this IServiceCollection services, IConfiguration Configuration)
        {
            //services.AddMemoryCache();
            services.AddDistributedMemoryCache(); //Change provider based on the need 
                                                  //One can use Redis, SQL or Custom Supported Cache

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Decorate pattern for MemoryCache.
            services.AddScoped<PaisRepository>();
            services.AddTransient<IPaisRepository, CachedMemoryPaisRepository>();

            services.AddScoped<DepartamentoRepository>();
            services.AddTransient<IDepartamentoRepository, CachedMemoryDepartamentoRepository>();

            services.AddScoped<MunicipioRepository>();
            services.AddTransient<IMunicipioRepository, CachedMemoryMunicipioRepository>();

            services.AddScoped<UserRepository>();
            services.AddTransient<IUserRepository, CachedMemoryUsuarioRepository>();

            services.AddScoped<OwnerRepository>();
            services.AddTransient<IOwnerRepository, CachedMemoryOwnerRepository>();

            services.AddScoped<PropertyRepository>();
            services.AddTransient<IPropertyRepository, CachedMemoryPropertyRepository>();

            services.AddScoped<IAuditTrailRepository, AuditTrailRepository>();
            return services;
        }
    }
}
