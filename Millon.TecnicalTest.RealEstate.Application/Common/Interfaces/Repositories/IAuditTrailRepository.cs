// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 04-02-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 04-12-2024
//  ****************************************************************
//  <copyright file="IAuditTrailRepository.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Application.Interfaces;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Audit;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories
{
    public interface IAuditTrailRepository : IRepository<AuditTrail, Guid>
    {
        Task<PagedList<AuditTrail>> GetAllAsync(ISpecificationQuery<AuditTrail> specification, int pageIndex, int pageSize, CancellationToken cancellationToken);
    }
}
