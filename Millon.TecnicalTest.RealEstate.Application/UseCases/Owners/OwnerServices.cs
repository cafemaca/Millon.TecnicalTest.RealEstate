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


using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Owners;
using Millon.TecnicalTest.RealEstate.Application.Common.Filtering;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories.Owners;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services.Owner;
using Millon.TecnicalTest.RealEstate.Application.Common.SpecificationQueries.Owners;
using Millon.TecnicalTest.RealEstate.Common.Application.Filtering;
using Millon.TecnicalTest.RealEstate.Common.Application.Interfaces;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Common.Application.Result;
using Millon.TecnicalTest.RealEstate.Common.Application.SpecificationQueries;
using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Domain.Common.Errors.Owners;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Owners;
using System.Linq.Expressions;

namespace Millon.TecnicalTest.RealEstate.Application.UseCases.Owners
{
    public class OwnerServices : IOwnerServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOwnerRepository _usuarioRepository;
        private readonly IValidator<OwnerCreateRequest> _createValidator;
        private readonly IValidator<OwnerUpdateRequest> _updateValidator;

        public OwnerServices(ILogger<OwnerServices> logger
            , IMapper mapper
            , IUnitOfWork unitOfWork
            , IOwnerRepository usuarioRepository
            , IValidator<OwnerCreateRequest> createValidator
            , IValidator<OwnerUpdateRequest> updateValidator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<Result<OwnerResponse?, IEnumerable<DomainError>>> CreateOwnerAsync(OwnerCreateRequest usuarioRequest, CancellationToken cancellationToken)
        {
            ValidationResult result = await _createValidator.ValidateAsync(usuarioRequest, cancellationToken).ConfigureAwait(false);
            if (result.IsValid)
            {
                Owner usuario = _mapper.Map<Owner>(usuarioRequest);

                await _usuarioRepository.InsertAsync(usuario, cancellationToken).ConfigureAwait(false);
                await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false); // save the changes to the database

                return _mapper.Map<OwnerResponse>(usuario);
            }
            else
            {
                return _mapper.Map<List<DomainError>>(result.Errors);
            }
        }

        public async Task<Result<bool, DomainError>> DeleteOwnerAsync(int id, CancellationToken cancellationToken)
        {
            Owner? usuario = await _usuarioRepository.GetAsync(id, cancellationToken).ConfigureAwait(false);
            if (usuario != null)
            {
                await _usuarioRepository.DeleteAsync(id, cancellationToken).ConfigureAwait(false);
                await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                return true;
            }
            else
            {
                return OwnerErrors.NotFound(id);
            }
        }

        public async Task<Result<IEnumerable<OwnerResponse>, DomainError>> SelectAllOwners(CancellationToken cancellationToken)
        {
            var usuarios = (await _usuarioRepository.GetAllAsync(new OwnerSpecificationQuery(), cancellationToken).ConfigureAwait(false)).ToList();
            return _mapper.Map<List<OwnerResponse>>(usuarios);
        }

        public async Task<Result<PagedList<OwnerResponse>, DomainError>> SelectAllOwners(SearchQueryParameters searchQueryParameters, CancellationToken cancellationToken)
        {
            #region Search filters
            List<ColumnFilter> columnFilters = CustomExpressionFilter<Owner>.GetColumnFilters(searchQueryParameters.ColumnFilters);

            List<ColumnSorting> columnSorting = CustomExpressionFilter<Owner>.GetColumnSorting(searchQueryParameters.OrderBy);
            #endregion

            Expression<Func<Owner, bool>> filters = null;
            List<SpecificationSort<Owner>> sorts = null;
            //First, we are checking our SearchTerm. If it contains information we are creating a filter.
            var searchTerm = "";
            if (!string.IsNullOrEmpty(searchQueryParameters.SearchTerm))
            {
                searchTerm = searchQueryParameters.SearchTerm.Trim().ToLower();
                filters = x => x.Name.ToLower().Contains(searchTerm);
            }
            // Then we are overwriting a filter if columnFilters has data.
            if (columnFilters.Count > 0)
            {
                filters = CustomExpressionFilter<Owner>.CustomFilter(columnFilters);
            }

            if (columnSorting.Count > 0)
            {
                sorts = CustomExpressionFilter<Owner>.CustomSort(columnSorting);
            }

            PagedList<Owner> usuarios = (await _usuarioRepository.GetAllAsync(new OwnerSpecificationQuery(filters, sorts), searchQueryParameters.PageIndex, searchQueryParameters.PageSize, cancellationToken));
            return _mapper.Map<PagedList<OwnerResponse>>(usuarios);
        }

        public async Task<Result<OwnerResponse?, DomainError>> SelectOwnerByIdAsync(int id, CancellationToken cancellationToken)
        {
            Owner? usuario = await _usuarioRepository.FirstOrDefaultAsync(new OwnerSpecificationQuery(id), cancellationToken).ConfigureAwait(false);
            if (usuario != null)
            {
                return _mapper.Map<OwnerResponse>(usuario);
            }
            else
            {
                return OwnerErrors.NotFound(id);
            }
        }

        public async Task<Result<bool, IEnumerable<DomainError>>> UpdateAsync(int id, OwnerUpdateRequest usuarioRequest, CancellationToken cancellationToken)
        {
            ValidationResult result = await _updateValidator.ValidateAsync(usuarioRequest, cancellationToken).ConfigureAwait(false);
            if (result.IsValid)
            {
                Owner? usuario = await _usuarioRepository.GetAsync(id, cancellationToken).ConfigureAwait(false);
                if (usuario != null)
                {
                    _mapper.Map<OwnerUpdateRequest, Owner>(usuarioRequest, usuario);
                    usuario.Id = id;

                    await _usuarioRepository.UpdateAsync(usuario, cancellationToken).ConfigureAwait(false);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);

                    return true;
                }
                else
                {
                    List<DomainError> errors = new List<DomainError>();
                    errors.Add(OwnerErrors.NotFound(id));
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
