// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Data
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-10-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-10-2025
//  ****************************************************************
//  <copyright file="PropertyRepository.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories.Properties;
using Millon.TecnicalTest.RealEstate.Application.Common.SpecificationQueries;
using Millon.TecnicalTest.RealEstate.Common.Application.Interfaces;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Common.Data.Repositories;
using Millon.TecnicalTest.RealEstate.Data.Context;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Properties;

namespace Millon.TecnicalTest.RealEstate.Data.Repositories.Properties
{
    public class PropertyRepository : EntityRepository<Property, int, RealEstateDbContext>, IPropertyRepository
    {
        public PropertyRepository(RealEstateDbContext context) : base(context)
        {
        }

        public async Task<PagedList<Property>> GetAllAsync(ISpecificationQuery<Property> specification, int pageIndex, int pageSize, CancellationToken cancellationToken)
        {

            return await PagedList<Property>.CreateAsync(SpecificationQueryBuilder.GetQuery(_dbSet, specification).AsQueryable<Property>(), pageIndex, pageSize);
        }
    }
}
