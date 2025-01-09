// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="IDepartamentoServices.cs"
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
    public interface IDepartamentoServices
    {
        Task<Result<IEnumerable<DepartamentoResponse>, DomainError>> SelectAllDepartamentos(CancellationToken cancellationToken);
        Task<Result<PagedList<DepartamentoResponse>, DomainError>> SelectAllDepartamentos(SearchQueryParameters searchQueryParameters, CancellationToken cancellationToken);
        Task<Result<DepartamentoResponse?, DomainError>> SelectDepartamentoByIdAsync(string id, CancellationToken cancellationToken);

        Task<Result<DepartamentoCreateResponse?, IEnumerable<DomainError>>> CreateDepartamentoAsync(DepartamentoCreateRequest departamentoRequest, CancellationToken cancellationToken);

        Task<Result<bool, DomainError>> DeleteDepartamentoAsync(string id, CancellationToken cancellationToken);

        Task<Result<bool, IEnumerable<DomainError>>> UpdateAsync(string id, DepartamentoUpdateRequest departamentoRequest, CancellationToken cancellationToken);
    }
}
