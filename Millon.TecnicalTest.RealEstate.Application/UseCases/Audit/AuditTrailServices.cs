using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Audit;
using Millon.TecnicalTest.RealEstate.Application.Common.Filtering;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services;
using Millon.TecnicalTest.RealEstate.Application.Common.SpecificationQueries.Audit;
using Millon.TecnicalTest.RealEstate.Common.Application.Filtering;
using Millon.TecnicalTest.RealEstate.Common.Application.Interfaces;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Common.Application.Result;
using Millon.TecnicalTest.RealEstate.Common.Application.SpecificationQueries;
using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Domain.Common.Errors;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Audit;

namespace Millon.TecnicalTest.RealEstate.Application.UseCases.Audit
{
    public class AuditTrailServices : IAuditTrailServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditTrailRepository _auditTrailRepository;

        public AuditTrailServices(ILogger<AuditTrailServices> logger
            , IMapper mapper
            , IUnitOfWork unitOfWork
            , IAuditTrailRepository auditTrailRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _auditTrailRepository = auditTrailRepository;
        }

        public async Task<Result<IEnumerable<AuditTrailResponse>, DomainError>> SelectAllAuditTrails(CancellationToken cancellationToken)
        {
            var auditTrails = (await _auditTrailRepository.GetAllAsync(cancellationToken).ConfigureAwait(false)).ToList();
            return _mapper.Map<List<AuditTrailResponse>>(auditTrails);
        }

        public async Task<Result<PagedList<AuditTrailResponse>, DomainError>> SelectAllAuditTrails(SearchQueryParameters searchQueryParameters, CancellationToken cancellationToken)
        {
            #region Search filters
            List<ColumnFilter> columnFilters = CustomExpressionFilter<AuditTrail>.GetColumnFilters(searchQueryParameters.ColumnFilters);

            List<ColumnSorting> columnSorting = CustomExpressionFilter<AuditTrail>.GetColumnSorting(searchQueryParameters.OrderBy);
            #endregion

            Expression<Func<AuditTrail, bool>> filters = null;
            List<SpecificationSort<AuditTrail>> sorts = null;
            //First, we are checking our SearchTerm. If it contains information we are creating a filter.
            var searchTerm = "";
            if (!string.IsNullOrEmpty(searchQueryParameters.SearchTerm))
            {
                searchTerm = searchQueryParameters.SearchTerm.Trim().ToLower();
                filters = x => x.EntityName.ToLower().Contains(searchTerm);
            }
            // Then we are overwriting a filter if columnFilters has data.
            if (columnFilters.Count > 0)
            {
                filters = CustomExpressionFilter<AuditTrail>.CustomFilter(columnFilters);
            }

            if (columnSorting.Count > 0)
            {
                sorts = CustomExpressionFilter<AuditTrail>.CustomSort(columnSorting);
            }

            PagedList<AuditTrail> auditTrails = (await _auditTrailRepository.GetAllAsync(new AuditTrailSpecificationQuery(filters, sorts), searchQueryParameters.PageIndex, searchQueryParameters.PageSize, cancellationToken));
            return _mapper.Map<PagedList<AuditTrailResponse>>(auditTrails);
        }

        public async Task<Result<AuditTrailResponse?, DomainError>> SelectAuditTrailByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            AuditTrail? auditTrail = await _auditTrailRepository.GetAsync(id, cancellationToken).ConfigureAwait(false);
            if (auditTrail != null)
            {
                return _mapper.Map<AuditTrailResponse>(auditTrail);
            }
            else
            {
                return AuditTrailErrors.NotFound(id);
            }
        }

    }
}
