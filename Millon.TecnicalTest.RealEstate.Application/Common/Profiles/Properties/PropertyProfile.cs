// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-10-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-10-2025
//  ****************************************************************
//  <copyright file="PropertyProfile.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using AutoMapper;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Properties;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Properties;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Profiles.Properties
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            CreateMap<PropertyCreateRequest, Property>()
                       .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                       .ForMember(dest => dest.Address, src => src.MapFrom(x => x.Address))
                       .ForMember(dest => dest.Price, src => src.MapFrom(x => x.Price))
                       .ForMember(dest => dest.CodeInternal, src => src.MapFrom(x => x.CodeInternal))
                       .ForMember(dest => dest.Year, src => src.MapFrom(x => x.Year))
                       .ForMember(dest => dest.IdOwner, src => src.MapFrom(x => x.IdOwner));

            CreateMap<PropertyUpdateRequest, Property>()
                       .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                       .ForMember(dest => dest.Address, src => src.MapFrom(x => x.Address))
                       .ForMember(dest => dest.Price, src => src.MapFrom(x => x.Price))
                       .ForMember(dest => dest.CodeInternal, src => src.MapFrom(x => x.CodeInternal))
                       .ForMember(dest => dest.Year, src => src.MapFrom(x => x.Year))
                       .ForMember(dest => dest.IdOwner, src => src.MapFrom(x => x.IdOwner));

            CreateMap<Property, PropertyResponse>()
                       .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                       .ForMember(dest => dest.Address, src => src.MapFrom(x => x.Address))
                       .ForMember(dest => dest.Price, src => src.MapFrom(x => x.Price))
                       .ForMember(dest => dest.CodeInternal, src => src.MapFrom(x => x.CodeInternal))
                       .ForMember(dest => dest.Year, src => src.MapFrom(x => x.Year))
                       .ForMember(dest => dest.IdOwner, src => src.MapFrom(x => x.IdOwner))
                       .ForMember(dest => dest.Owner, src => src.MapFrom(x => x.Owner))
                       .ForMember(dest => dest.Images, src => src.MapFrom(x => x.Images))
                       .ForMember(dest => dest.Traces, src => src.MapFrom(x => x.Traces));

            CreateMap<PropertyUpdatePriceRequest, Property>()
                       .ForMember(dest => dest.Price, src => src.MapFrom(x => x.Price));

        }
    }
}
