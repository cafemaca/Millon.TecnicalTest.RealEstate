// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-09-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-09-2025
//  ****************************************************************
//  <copyright file="DepartamentoRequest.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Owners;
using Millon.TecnicalTest.RealEstate.Common.Application.Filtering;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Common.Application.Result;
using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services.Owner
{
    public interface IOwnerServices
    {
        Task<Result<IEnumerable<OwnerResponse>, DomainError>> SelectAllOwners(CancellationToken cancellationToken);
        Task<Result<PagedList<OwnerResponse>, DomainError>> SelectAllOwners(SearchQueryParameters searchQueryParameters, CancellationToken cancellationToken);
        Task<Result<OwnerResponse?, DomainError>> SelectOwnerByIdAsync(int id, CancellationToken cancellationToken);

        Task<Result<OwnerResponse?, IEnumerable<DomainError>>> CreateOwnerAsync(OwnerCreateRequest ownerRequest, CancellationToken cancellationToken);

        Task<Result<bool, DomainError>> DeleteOwnerAsync(int id, CancellationToken cancellationToken);

        Task<Result<bool, IEnumerable<DomainError>>> UpdateAsync(int id, OwnerUpdateRequest ownerRequest, CancellationToken cancellationToken);
    }
}
