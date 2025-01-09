// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-09-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-09-2024
//  ****************************************************************
//  <copyright file="DependecyInjection.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Location;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Owners;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Users;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services.Location;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services.Owner;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services.Users;
using Millon.TecnicalTest.RealEstate.Application.Common.Profiles;
using Millon.TecnicalTest.RealEstate.Application.Common.Validators.Location;
using Millon.TecnicalTest.RealEstate.Application.Common.Validators.Owners;
using Millon.TecnicalTest.RealEstate.Application.Common.Validators.Users;
using Millon.TecnicalTest.RealEstate.Application.UseCases.Audit;
using Millon.TecnicalTest.RealEstate.Application.UseCases.Location;
using Millon.TecnicalTest.RealEstate.Application.UseCases.Owners;
using Millon.TecnicalTest.RealEstate.Application.UseCases.Users;
using Millon.TecnicalTest.RealEstatea.Application.UseCases.Location;

namespace Millon.TecnicalTest.RealEstate.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            #region Validators

            services.AddTransient<IValidator<PaisCreateRequest>, PaisCreateRequestValidator>();
            services.AddTransient<IValidator<PaisUpdateRequest>, PaisUpdateRequestValidator>();

            services.AddTransient<IValidator<DepartamentoCreateRequest>, DepartamentoCreateRequestValidator>();
            services.AddTransient<IValidator<DepartamentoUpdateRequest>, DepartamentoUpdateRequestValidator>();

            services.AddTransient<IValidator<MunicipioCreateRequest>, MunicipioCreateRequestValidator>();
            services.AddTransient<IValidator<MunicipioUpdateRequest>, MunicipioUpdateRequestValidator>();

            services.AddTransient<IValidator<UserCreateRequest>, UserCreateRequestValidator>();
            services.AddTransient<IValidator<UserUpdateRequest>, UserUpdateRequestValidator>();

            services.AddTransient<IValidator<OwnerCreateRequest>, OwnerCreateRequestValidator>();
            services.AddTransient<IValidator<OwnerUpdateRequest>, OwnerUpdateRequestValidator>();

            #endregion

            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

            #region Services
            services.AddScoped<IPaisServices, PaisServices>();
            services.AddScoped<IDepartamentoServices, DepartamentoServices>();
            services.AddScoped<IMunicipioServices, MunicipioServices>();

            services.AddScoped<IUserServices, UsuarioServices>();

            services.AddScoped<IOwnerServices, OwnerServices>();

            services.AddScoped<IAuditTrailServices, AuditTrailServices>();
            #endregion

            return services;
        }
    }
}
