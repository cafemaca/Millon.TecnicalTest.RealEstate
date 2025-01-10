// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-10-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-10-2025
//  ****************************************************************
//  <copyright file="PropertyServices.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Properties;
using Millon.TecnicalTest.RealEstate.Application.Common.Filtering;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories.Properties;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services.Properties;
using Millon.TecnicalTest.RealEstate.Application.Common.SpecificationQueries.Properties;
using Millon.TecnicalTest.RealEstate.Common.Application.Filtering;
using Millon.TecnicalTest.RealEstate.Common.Application.Interfaces;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Common.Application.Result;
using Millon.TecnicalTest.RealEstate.Common.Application.SpecificationQueries;
using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Domain.Common.Errors.Properties;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Properties;
using System.Linq.Expressions;

namespace Millon.TecnicalTest.RealEstate.Application.UseCases.Properties
{
    public class PropertyServices : IPropertyServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IValidator<PropertyCreateRequest> _createValidator;
        private readonly IValidator<PropertyUpdateRequest> _updateValidator;

        public PropertyServices(ILogger<PropertyServices> logger
            , IMapper mapper
            , IUnitOfWork unitOfWork
            , IPropertyRepository propertyRepository
            , IValidator<PropertyCreateRequest> createValidator
            , IValidator<PropertyUpdateRequest> updateValidator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _propertyRepository = propertyRepository ?? throw new ArgumentNullException(nameof(propertyRepository));
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<Result<PropertyResponse?, IEnumerable<DomainError>>> CreatePropertyAsync(PropertyCreateRequest propertyRequest, CancellationToken cancellationToken)
        {
            ValidationResult result = await _createValidator.ValidateAsync(propertyRequest, cancellationToken).ConfigureAwait(false);
            if (result.IsValid)
            {
                Property property = _mapper.Map<Property>(propertyRequest);

                await _propertyRepository.InsertAsync(property, cancellationToken).ConfigureAwait(false);
                await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false); // save the changes to the database

                return _mapper.Map<PropertyResponse>(property);
            }
            else
            {
                return _mapper.Map<List<DomainError>>(result.Errors);
            }
        }

        public async Task<Result<bool, DomainError>> DeletePropertyAsync(int id, CancellationToken cancellationToken)
        {
            Property? property = await _propertyRepository.GetAsync(id, cancellationToken).ConfigureAwait(false);
            if (property != null)
            {
                await _propertyRepository.DeleteAsync(id, cancellationToken).ConfigureAwait(false);
                await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                return true;
            }
            else
            {
                return PropertyErrors.NotFound(id);
            }
        }

        public async Task<Result<IEnumerable<PropertyResponse>, DomainError>> SelectAllProperties(CancellationToken cancellationToken)
        {
            var propertys = (await _propertyRepository.GetAllAsync(new PropertySpecificationQuery(), cancellationToken).ConfigureAwait(false)).ToList();
            return _mapper.Map<List<PropertyResponse>>(propertys);
        }

        public async Task<Result<PagedList<PropertyResponse>, DomainError>> SelectAllProperties(SearchQueryParameters searchQueryParameters, CancellationToken cancellationToken)
        {
            #region Search filters
            List<ColumnFilter> columnFilters = CustomExpressionFilter<Property>.GetColumnFilters(searchQueryParameters.ColumnFilters);

            List<ColumnSorting> columnSorting = CustomExpressionFilter<Property>.GetColumnSorting(searchQueryParameters.OrderBy);
            #endregion

            Expression<Func<Property, bool>> filters = null;
            List<SpecificationSort<Property>> sorts = null;
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
                filters = CustomExpressionFilter<Property>.CustomFilter(columnFilters);
            }

            if (columnSorting.Count > 0)
            {
                sorts = CustomExpressionFilter<Property>.CustomSort(columnSorting);
            }

            PagedList<Property> propertys = (await _propertyRepository.GetAllAsync(new PropertySpecificationQuery(filters, sorts), searchQueryParameters.PageIndex, searchQueryParameters.PageSize, cancellationToken));
            return _mapper.Map<PagedList<PropertyResponse>>(propertys);
        }

        public async Task<Result<PropertyResponse?, DomainError>> SelectPropertyByIdAsync(int id, CancellationToken cancellationToken)
        {
            Property? property = await _propertyRepository.FirstOrDefaultAsync(new PropertySpecificationQuery(id), cancellationToken).ConfigureAwait(false);
            if (property != null)
            {
                return _mapper.Map<PropertyResponse>(property);
            }
            else
            {
                return PropertyErrors.NotFound(id);
            }
        }

        public async Task<Result<bool, IEnumerable<DomainError>>> UpdateAsync(int id, PropertyUpdateRequest propertyRequest, CancellationToken cancellationToken)
        {
            ValidationResult result = await _updateValidator.ValidateAsync(propertyRequest, cancellationToken).ConfigureAwait(false);
            if (result.IsValid)
            {
                Property? property = await _propertyRepository.GetAsync(id, cancellationToken).ConfigureAwait(false);
                if (property != null)
                {
                    _mapper.Map<PropertyUpdateRequest, Property>(propertyRequest, property);
                    property.Id = id;

                    await _propertyRepository.UpdateAsync(property, cancellationToken).ConfigureAwait(false);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);

                    return true;
                }
                else
                {
                    List<DomainError> errors = new List<DomainError>();
                    errors.Add(PropertyErrors.NotFound(id));
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
