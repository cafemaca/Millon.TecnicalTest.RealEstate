// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="DireccionProfile.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using AutoMapper;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Users;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Users;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Profiles.User
{
    public class DireccionProfile : Profile
    {
        public DireccionProfile()
        {
            CreateMap<DireccionRequest, Direccion>()
                       .ForMember(dest => dest.DireccionName, src => src.MapFrom(x => x.DireccionName))
                       .ForMember(dest => dest.Municipioid, src => src.MapFrom(x => x.MunicipioId));

            CreateMap<Direccion, DireccionResponse>()
                       .ForMember(dest => dest.DireccionName, src => src.MapFrom(x => x.DireccionName))
                       .ForMember(dest => dest.Municipio, src => src.MapFrom(x => x.Municipio));

        }
    }
}
