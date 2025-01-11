﻿// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-10-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-10-2025
//  ****************************************************************
//  <copyright file="IPropertyServices.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Properties;
using Millon.TecnicalTest.RealEstate.Common.Application.Filtering;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Common.Application.Result;
using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services.Properties
{
    public interface IPropertyServices
    {
        Task<Result<IEnumerable<PropertyResponse>, DomainError>> SelectAllProperties(CancellationToken cancellationToken);
        Task<Result<PagedList<PropertyResponse>, DomainError>> SelectAllProperties(SearchQueryParameters searchQueryParameters, CancellationToken cancellationToken);
        Task<Result<PropertyResponse?, DomainError>> SelectPropertyByIdAsync(int id, CancellationToken cancellationToken);

        Task<Result<PropertyResponse?, IEnumerable<DomainError>>> CreatePropertyAsync(PropertyCreateRequest propertyRequest, CancellationToken cancellationToken);

        Task<Result<bool, DomainError>> DeletePropertyAsync(int id, CancellationToken cancellationToken);

        Task<Result<bool, IEnumerable<DomainError>>> UpdateAsync(int id, PropertyUpdateRequest propertyRequest, CancellationToken cancellationToken);
        Task<Result<bool, IEnumerable<DomainError>>> UpdatePriceAsync(int id, PropertyUpdatePriceRequest propertyRequest, CancellationToken cancellationToken);
        Task<Result<bool, IEnumerable<DomainError>>> AddImageAsync(int id, PropertyImageCreateRequest propertyImageCreateRequest, CancellationToken cancellationToken);
    }
}
