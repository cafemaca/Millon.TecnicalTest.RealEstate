using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories;
using Millon.TecnicalTest.RealEstate.Application.Common.SpecificationQueries;
using Millon.TecnicalTest.RealEstate.Common.Application.Interfaces;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Common.Data.Repositories;
using Millon.TecnicalTest.RealEstate.Data.Context;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Audit;

namespace Millon.TecnicalTest.RealEstate.Data.Repositories.Audit
{
    public class AuditTrailRepository : EntityRepository<AuditTrail, Guid, CafemacaDbContext>, IAuditTrailRepository
    {
        public AuditTrailRepository(CafemacaDbContext context) : base(context)
        {
        }

        public async Task<PagedList<AuditTrail>> GetAllAsync(ISpecificationQuery<AuditTrail> specification, int pageIndex, int pageSize, CancellationToken cancellationToken)
        {

            return await PagedList<AuditTrail>.CreateAsync(SpecificationQueryBuilder.GetQuery(_dbSet, specification).AsQueryable<AuditTrail>(), pageIndex, pageSize);
        }
    }
}
