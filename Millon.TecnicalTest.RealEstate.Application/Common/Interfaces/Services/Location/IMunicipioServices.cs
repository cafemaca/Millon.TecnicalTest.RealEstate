// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="IMunicipioServices.cs"
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
    public interface IMunicipioServices
    {
        Task<Result<IEnumerable<MunicipioResponse>, DomainError>> SelectAllMunicipios(CancellationToken cancellationToken);
        Task<Result<PagedList<MunicipioResponse>, DomainError>> SelectAllMunicipios(SearchQueryParameters searchQueryParameters, CancellationToken cancellationToken);
        Task<Result<MunicipioResponse?, DomainError>> SelectMunicipioByIdAsync(string id, CancellationToken cancellationToken);

        Task<Result<MunicipioResponse?, IEnumerable<DomainError>>> CreateMunicipioAsync(MunicipioCreateRequest municipioRequest, CancellationToken cancellationToken);

        Task<Result<bool, DomainError>> DeleteMunicipioAsync(string id, CancellationToken cancellationToken);

        Task<Result<bool, IEnumerable<DomainError>>> UpdateAsync(string id, MunicipioUpdateRequest municipioRequest, CancellationToken cancellationToken);
    }
}
