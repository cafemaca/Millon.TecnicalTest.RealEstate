// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="MunicipioProfile.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using AutoMapper;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Location;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Location;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Profiles.Location
{
    public class MunicipioProfile : Profile
    {
        public MunicipioProfile()
        {
            CreateMap<MunicipioCreateRequest, Municipio>()
                       .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                       .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                       .ForMember(dest => dest.DepartamentoId, src => src.MapFrom(x => x.DepartamentoId));

            CreateMap<MunicipioUpdateRequest, Municipio>()
                       .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                       .ForMember(dest => dest.DepartamentoId, src => src.MapFrom(x => x.DepartamentoId));

            CreateMap<Municipio, MunicipioResponse>()
                       .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                       .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                       .ForMember(dest => dest.Departamento, src => src.MapFrom(x => x.Departamento));

        }
    }
}
