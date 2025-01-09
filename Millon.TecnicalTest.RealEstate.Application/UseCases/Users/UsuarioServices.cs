// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="UsuarioServices.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using System.Linq.Expressions;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Users;
using Millon.TecnicalTest.RealEstate.Application.Common.Filtering;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories.Users;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services.Users;
using Millon.TecnicalTest.RealEstate.Application.Common.SpecificationQueries.Users;
using Millon.TecnicalTest.RealEstate.Common.Application.Filtering;
using Millon.TecnicalTest.RealEstate.Common.Application.Interfaces;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Common.Application.Result;
using Millon.TecnicalTest.RealEstate.Common.Application.SpecificationQueries;
using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Domain.Common.Errors.Users;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Users;

namespace Millon.TecnicalTest.RealEstate.Application.UseCases.Users
{
    public class UsuarioServices : IUserServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _usuarioRepository;
        private readonly IValidator<UserCreateRequest> _createValidator;
        private readonly IValidator<UserUpdateRequest> _updateValidator;

        public UsuarioServices(ILogger<UsuarioServices> logger
            , IMapper mapper
            , IUnitOfWork unitOfWork
            , IUserRepository usuarioRepository
            , IValidator<UserCreateRequest> createValidator
            , IValidator<UserUpdateRequest> updateValidator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<Result<UserResponse?, IEnumerable<DomainError>>> CreateUsuarioAsync(UserCreateRequest usuarioRequest, CancellationToken cancellationToken)
        {
            ValidationResult result = await _createValidator.ValidateAsync(usuarioRequest, cancellationToken).ConfigureAwait(false);
            if (result.IsValid)
            {
                Usuario usuario = _mapper.Map<Usuario>(usuarioRequest);

                await _usuarioRepository.InsertAsync(usuario, cancellationToken).ConfigureAwait(false);
                await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false); // save the changes to the database

                return _mapper.Map<UserResponse>(usuario);
            }
            else
            {
                return _mapper.Map<List<DomainError>>(result.Errors);
            }
        }

        public async Task<Result<bool, DomainError>> DeleteUsuarioAsync(string id, CancellationToken cancellationToken)
        {
            Usuario? usuario = await _usuarioRepository.GetAsync(id, cancellationToken).ConfigureAwait(false);
            if (usuario != null)
            {
                await _usuarioRepository.DeleteAsync(id, cancellationToken).ConfigureAwait(false);
                await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                return true;
            }
            else
            {
                return UserErrors.NotFound(id);
            }
        }

        public async Task<Result<IEnumerable<UserResponse>, DomainError>> SelectAllUsuarios(CancellationToken cancellationToken)
        {
            var usuarios = (await _usuarioRepository.GetAllAsync(new UserSpecificationQuery(), cancellationToken).ConfigureAwait(false)).ToList();
            return _mapper.Map<List<UserResponse>>(usuarios);
        }

        public async Task<Result<PagedList<UserResponse>, DomainError>> SelectAllUsuarios(SearchQueryParameters searchQueryParameters, CancellationToken cancellationToken)
        {
            #region Search filters
            List<ColumnFilter> columnFilters = CustomExpressionFilter<Usuario>.GetColumnFilters(searchQueryParameters.ColumnFilters);

            List<ColumnSorting> columnSorting = CustomExpressionFilter<Usuario>.GetColumnSorting(searchQueryParameters.OrderBy);
            #endregion

            Expression<Func<Usuario, bool>> filters = null;
            List<SpecificationSort<Usuario>> sorts = null;
            //First, we are checking our SearchTerm. If it contains information we are creating a filter.
            var searchTerm = "";
            if (!string.IsNullOrEmpty(searchQueryParameters.SearchTerm))
            {
                searchTerm = searchQueryParameters.SearchTerm.Trim().ToLower();
                filters = x => x.Nombre.ToLower().Contains(searchTerm);
            }
            // Then we are overwriting a filter if columnFilters has data.
            if (columnFilters.Count > 0)
            {
                filters = CustomExpressionFilter<Usuario>.CustomFilter(columnFilters);
            }

            if (columnSorting.Count > 0)
            {
                sorts = CustomExpressionFilter<Usuario>.CustomSort(columnSorting);
            }

            PagedList<Usuario> usuarios = (await _usuarioRepository.GetAllAsync(new UserSpecificationQuery(filters, sorts), searchQueryParameters.PageIndex, searchQueryParameters.PageSize, cancellationToken));
            return _mapper.Map<PagedList<UserResponse>>(usuarios);
        }

        public async Task<Result<UserResponse?, DomainError>> SelectUsuarioByIdAsync(string id, CancellationToken cancellationToken)
        {
            Usuario? usuario = await _usuarioRepository.FirstOrDefaultAsync(new UserSpecificationQuery(id), cancellationToken).ConfigureAwait(false);
            if (usuario != null)
            {
                return _mapper.Map<UserResponse>(usuario);
            }
            else
            {
                return UserErrors.NotFound(id);
            }
        }

        public async Task<Result<bool, IEnumerable<DomainError>>> UpdateAsync(string id, UserUpdateRequest usuarioRequest, CancellationToken cancellationToken)
        {
            ValidationResult result = await _updateValidator.ValidateAsync(usuarioRequest, cancellationToken).ConfigureAwait(false);
            if (result.IsValid)
            {
                Usuario? usuario = await _usuarioRepository.GetAsync(id, cancellationToken).ConfigureAwait(false);
                if (usuario != null)
                {
                    _mapper.Map<UserUpdateRequest, Usuario>(usuarioRequest, usuario);
                    usuario.Id = id;

                    await _usuarioRepository.UpdateAsync(usuario, cancellationToken).ConfigureAwait(false);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);

                    return true;
                }
                else
                {
                    List<DomainError> errors = new List<DomainError>();
                    errors.Add(UserErrors.NotFound(id));
                    return errors;
                }
            }
            else
            {
                return _mapper.Map<List<DomainError>>(result.Errors);
            }
        }
    }
}
