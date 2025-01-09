using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Audit;
using Millon.TecnicalTest.RealEstate.Common.Application.Filtering;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Common.Application.Result;
using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services
{
    public interface IAuditTrailServices
    {
        Task<Result<IEnumerable<AuditTrailResponse>, DomainError>> SelectAllAuditTrails(CancellationToken cancellationToken);
        Task<Result<PagedList<AuditTrailResponse>, DomainError>> SelectAllAuditTrails(SearchQueryParameters searchQueryParameters, CancellationToken cancellationToken);
        Task<Result<AuditTrailResponse?, DomainError>> SelectAuditTrailByIdAsync(Guid id, CancellationToken cancellationToken);

        //Task<Result<AuditTrailResponse?, IEnumerable<DomainError>>> CreateAuditTrailAsync(AuditTrailRequest AuditTrailRequest, CancellationToken cancellationToken);

        //Task<Result<bool, DomainError>> DeleteAuditTrailAsync(Guid id, CancellationToken cancellationToken);

        //Task<Result<bool, IEnumerable<DomainError>>> UpdateAsync(Guid id, AuditTrailRequest AuditTrailRequest, CancellationToken cancellationToken);
    }
}
