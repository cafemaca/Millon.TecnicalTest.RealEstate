// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-10-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-10-2025
//  ****************************************************************
//  <copyright file="PropertyImageImageProfile.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using AutoMapper;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Properties;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Properties;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Profiles.Properties
{
    public class PropertyImageProfile : Profile
    {
        public PropertyImageProfile()
        {
            CreateMap<PropertyImageCreateRequest, PropertyImage>()
                       .ForMember(dest => dest.File, src => src.MapFrom(x => x.File))
                       .ForMember(dest => dest.Enabled, src => src.MapFrom(x => x.Enabled));

            CreateMap<PropertyImageUpdateRequest, PropertyImage>()
                       .ForMember(dest => dest.File, src => src.MapFrom(x => x.File))
                       .ForMember(dest => dest.Enabled, src => src.MapFrom(x => x.Enabled));

            CreateMap<PropertyImage, PropertyImageResponse>()
                       .ForMember(dest => dest.File, src => src.MapFrom(x => x.File))
                       .ForMember(dest => dest.Enabled, src => src.MapFrom(x => x.Enabled));
        }
    }
}
