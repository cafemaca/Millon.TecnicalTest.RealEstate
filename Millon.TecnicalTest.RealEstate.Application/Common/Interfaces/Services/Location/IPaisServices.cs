// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="IPaisServices.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Location;
using Millon.TecnicalTest.RealEstate.Common.Application.Filtering;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Common.Application.Result;
using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services.Location
{
    public interface IPaisServices
    {
        Task<Result<IEnumerable<PaisResponse>, DomainError>> SelectAllPaises(CancellationToken cancellationToken);
        Task<Result<PagedList<PaisResponse>, DomainError>> SelectAllPaises(SearchQueryParameters searchQueryParameters, CancellationToken cancellationToken);
        Task<Result<PaisResponse?, DomainError>> SelectPaisByIdAsync(string id, CancellationToken cancellationToken);

        Task<Result<PaisResponse?, IEnumerable<DomainError>>> CreatePaisAsync(PaisCreateRequest paisRequest, CancellationToken cancellationToken);

        Task<Result<bool, DomainError>> DeletePaisAsync(string id, CancellationToken cancellationToken);

        Task<Result<bool, IEnumerable<DomainError>>> UpdateAsync(string id, PaisUpdateRequest paisRequest, CancellationToken cancellationToken);
    }
}
