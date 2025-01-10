// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-10-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-10-2025
//  ****************************************************************
//  <copyright file="IPropertyRepository.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using Millon.TecnicalTest.RealEstate.Common.Application.Interfaces;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Properties;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories.Properties
{
    public interface IPropertyRepository : IRepository<Property, int>
    {
        // add methods that are specific to the Player entity
        // e.g Task<Player> GetByEmail(string email);
        // e.g Task<Player> GetByName(string name);
        // e.g Task<Player> GetByEmailAndPassword(string email, string password);
        //Task<PagedList<Player>> GetItems(int pageIndex, int pageSize);

        Task<PagedList<Property>> GetAllAsync(ISpecificationQuery<Property> specification, int pageIndex, int pageSize, CancellationToken cancellationToken);
    }
}
