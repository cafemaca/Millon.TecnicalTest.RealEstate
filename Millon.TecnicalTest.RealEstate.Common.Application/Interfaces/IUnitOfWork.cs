﻿// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 04-02-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 04-02-2024
//  ****************************************************************
//  <copyright file="IUnitOfWork.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

namespace Millon.TecnicalTest.RealEstate.Common.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellation); // this method will save all the changes made to the database
    }
}
