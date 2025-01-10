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


using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Owners;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Owners;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Properties
{
    public class PropertyResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Price { get; set; }
        public string CodeInternal { get; set; } = string.Empty;
        public int Year { get; set; }

        public int IdOwner { get; set; }
        public OwnerResponse Owner { get; set; }


        public ICollection<PropertyImageResponse> Images { get; set; }
        public ICollection<PropertyTraceResponse> Traces { get; set; }
    }
}
