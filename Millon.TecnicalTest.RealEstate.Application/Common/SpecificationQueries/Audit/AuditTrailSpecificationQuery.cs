using System.Linq.Expressions;
using Millon.TecnicalTest.RealEstate.Common.Application.SpecificationQueries;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Audit;

namespace Millon.TecnicalTest.RealEstate.Application.Common.SpecificationQueries.Audit
{
    public class AuditTrailSpecificationQuery : BaseSpecificationQuery<AuditTrail>
    {
        public AuditTrailSpecificationQuery() : base()
        {
        }
        public AuditTrailSpecificationQuery(Expression<Func<AuditTrail, bool>> criteria, List<SpecificationSort<AuditTrail>> orderby) : base(criteria)
        {
            OrderBy = orderby;
        }
    }
}
