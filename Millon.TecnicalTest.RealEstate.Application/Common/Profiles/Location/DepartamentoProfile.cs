﻿// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-102024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="DepartamentoProfile.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using AutoMapper;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Location;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Location;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Profiles.Location
{
    public class DepartamentoProfile : Profile
    {
        public DepartamentoProfile()
        {
            CreateMap<DepartamentoCreateRequest, Departamento>()
                       .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                       .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                       .ForMember(dest => dest.PaisId, src => src.MapFrom(x => x.PaisId));

            CreateMap<DepartamentoUpdateRequest, Departamento>()
                       .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name));

            CreateMap<Departamento, DepartamentoResponse>()
                       .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                       .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                       .ForMember(dest => dest.Pais, src => src.MapFrom(x => x.Pais));

            CreateMap<Departamento, DepartamentoCreateResponse>()
                       .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                       .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                       .ForMember(dest => dest.PaisId, src => src.MapFrom(x => x.PaisId));

        }
    }
}
