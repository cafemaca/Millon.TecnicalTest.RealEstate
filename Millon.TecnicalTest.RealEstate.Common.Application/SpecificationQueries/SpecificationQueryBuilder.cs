// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Data
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 07-16-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 07-16-2024
//  ****************************************************************
//  <copyright file="ApplicationDbContext.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Microsoft.EntityFrameworkCore;
using Millon.TecnicalTest.RealEstate.Common.Application.Interfaces;

namespace Millon.TecnicalTest.RealEstate.Application.Common.SpecificationQueries
{
    /// <summary>
    /// Constructor the Specification Query
    /// </summary>
    public static class SpecificationQueryBuilder
    {
        public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery, ISpecificationQuery<TEntity> specificationQuery) where TEntity : class
        {
            IOrderedQueryable<TEntity> querySort = null;
            var query = inputQuery;

            if (specificationQuery.Criteria != null)
            {
                query = query.Where(specificationQuery.Criteria);
            }
            if (specificationQuery.Includes.Any())
            {
                query = specificationQuery.Includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (specificationQuery.IncludeStrings.Any())
            {
                query = specificationQuery.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));
            }
            if (specificationQuery.OrderBy != null)
            {
                if (specificationQuery.OrderBy.Count > 0)
                {
                    if (!specificationQuery.OrderBy[0].Desc)
                    {
                        querySort = query.OrderBy(specificationQuery.OrderBy[0].PropertySort);
                    }
                    else
                    {
                        querySort = query.OrderByDescending(specificationQuery.OrderBy[0].PropertySort);
                    }
                    for (int i = 1; i < specificationQuery.OrderBy.Count; i++)
                    {
                        if (!specificationQuery.OrderBy[i].Desc)
                        {
                            querySort.ThenBy(specificationQuery.OrderBy[i].PropertySort);
                        }
                        else
                        {
                            querySort.ThenByDescending(specificationQuery.OrderBy[i].PropertySort);
                        }
                    }
                }
            }
            else
            {
                return query.AsQueryable<TEntity>();
            }

            return querySort.AsQueryable<TEntity>();
        }
    }
}
