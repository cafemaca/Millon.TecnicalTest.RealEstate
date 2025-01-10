// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-10-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-10-2025
//  ****************************************************************
//  <copyright file="PropertyImageUpdateRequest.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


namespace Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Properties
{
    public class PropertyImageUpdateRequest
    {
        public string File { get; set; } = string.Empty;
        public bool Enabled { get; set; }
    }
}
