﻿// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="IPais.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Application.Interfaces;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Location;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Repositories.Location
{
    public interface IPaisRepository : IRepository<Pais, string>
    {
        // add methods that are specific to the Player entity
        // e.g Task<Player> GetByEmail(string email);
        // e.g Task<Player> GetByName(string name);
        // e.g Task<Player> GetByEmailAndPassword(string email, string password);
        //Task<PagedList<Player>> GetItems(int pageIndex, int pageSize);

        Task<PagedList<Pais>> GetAllAsync(ISpecificationQuery<Pais> specification, int pageIndex, int pageSize, CancellationToken cancellationToken);
    }
}
