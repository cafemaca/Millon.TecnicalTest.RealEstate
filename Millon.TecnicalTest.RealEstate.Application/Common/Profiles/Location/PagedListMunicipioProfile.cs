﻿// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="PagedListMunicipioProfile.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using AutoMapper;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Location;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Location;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Profiles.Location
{
    public class PagedListMunicipioProfile : Profile
    {
        public PagedListMunicipioProfile()
        {
            CreateMap<PagedList<Municipio>, PagedList<MunicipioResponse>>()
                       .ForMember(dest => dest.PageSize, src => src.MapFrom(x => x.PageSize))
                       .ForMember(dest => dest.CurrentPage, src => src.MapFrom(x => x.CurrentPage))
                       .ForMember(dest => dest.TotalItemCount, src => src.MapFrom(x => x.TotalItemCount))
                       .ForMember(dest => dest.TotalPageCount, src => src.MapFrom(x => x.TotalPageCount))
                       .ForMember(dest => dest.Items, src => src.MapFrom(x => x.Items));

        }
    }
}
