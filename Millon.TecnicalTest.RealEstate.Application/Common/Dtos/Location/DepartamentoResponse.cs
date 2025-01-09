﻿// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="DepartamentoResponse.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

namespace Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Location
{
    public class DepartamentoResponse
    {
        public required string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public PaisResponse Pais { get; set; }
    }
}
