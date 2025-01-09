// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="DireccionRequest.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

namespace Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Users
{
    public class DireccionRequest
    {
        public string DireccionName { get; set; } = string.Empty;
        public string MunicipioId { get; set; } = default;
    }
}
