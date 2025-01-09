// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-09-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-09-2025
//  ****************************************************************
//  <copyright file="DepartamentoRequest.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

namespace Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Owners
{
    public class OwnerCreateRequest
    {
        public required string Name { get; set; } = string.Empty;
        public required string Address { get; set; } = string.Empty;

        public required string Photo { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }
    }
}
