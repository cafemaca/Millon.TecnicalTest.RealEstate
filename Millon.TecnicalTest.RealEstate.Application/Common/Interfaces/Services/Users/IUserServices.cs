// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="IUsuarioServices.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Users;
using Millon.TecnicalTest.RealEstate.Common.Application.Filtering;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Common.Application.Result;
using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services.Users
{
    public interface IUserServices
    {
        Task<Result<IEnumerable<UserResponse>, DomainError>> SelectAllUsuarios(CancellationToken cancellationToken);
        Task<Result<PagedList<UserResponse>, DomainError>> SelectAllUsuarios(SearchQueryParameters searchQueryParameters, CancellationToken cancellationToken);
        Task<Result<UserResponse?, DomainError>> SelectUsuarioByIdAsync(string id, CancellationToken cancellationToken);

        Task<Result<UserResponse?, IEnumerable<DomainError>>> CreateUsuarioAsync(UserCreateRequest playerRequest, CancellationToken cancellationToken);

        Task<Result<bool, DomainError>> DeleteUsuarioAsync(string id, CancellationToken cancellationToken);

        Task<Result<bool, IEnumerable<DomainError>>> UpdateAsync(string id, UserUpdateRequest playerRequest, CancellationToken cancellationToken);
    }
}
