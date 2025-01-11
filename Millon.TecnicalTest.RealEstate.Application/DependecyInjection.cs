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

using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Owners;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Properties;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services.Owner;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services.Properties;
using Millon.TecnicalTest.RealEstate.Application.Common.Profiles;
using Millon.TecnicalTest.RealEstate.Application.Common.Validators.Owners;
using Millon.TecnicalTest.RealEstate.Application.Common.Validators.Properties;
using Millon.TecnicalTest.RealEstate.Application.UseCases.Audit;
using Millon.TecnicalTest.RealEstate.Application.UseCases.Owners;
using Millon.TecnicalTest.RealEstate.Application.UseCases.Properties;
using System.Reflection;

namespace Millon.TecnicalTest.RealEstate.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            #region Validators

            services.AddTransient<IValidator<OwnerCreateRequest>, OwnerCreateRequestValidator>();
            services.AddTransient<IValidator<OwnerUpdateRequest>, OwnerUpdateRequestValidator>();

            services.AddTransient<IValidator<PropertyCreateRequest>, PropertyCreateRequestValidator>();
            services.AddTransient<IValidator<PropertyUpdateRequest>, PropertyUpdateRequestValidator>();
            services.AddTransient<IValidator<PropertyUpdatePriceRequest>, PropertyUpdatePriceRequestValidator>();
            services.AddTransient<IValidator<PropertyImageCreateRequest>, PropertyAddImageRequestValidator>();

            #endregion

            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

            #region Services
            services.AddScoped<IOwnerServices, OwnerServices>();
            services.AddScoped<IPropertyServices, PropertyServices>();

            services.AddScoped<IAuditTrailServices, AuditTrailServices>();
            #endregion

            return services;
        }
    }
}
