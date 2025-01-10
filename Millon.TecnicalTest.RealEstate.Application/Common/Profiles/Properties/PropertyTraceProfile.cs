// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-10-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-10-2025
//  ****************************************************************
//  <copyright file="PropertyTraceProfile.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using AutoMapper;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Properties;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Properties;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Profiles.Properties
{
    public class PropertyTraceProfile : Profile
    {
        public PropertyTraceProfile()
        {
            CreateMap<PropertyTraceCreateRequest, PropertyTrace>()
                       .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                       .ForMember(dest => dest.Value, src => src.MapFrom(x => x.Value))
                       .ForMember(dest => dest.Tax, src => src.MapFrom(x => x.Tax));

            CreateMap<PropertyTraceUpdateRequest, PropertyTrace>()
                       .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                       .ForMember(dest => dest.Value, src => src.MapFrom(x => x.Value))
                       .ForMember(dest => dest.Tax, src => src.MapFrom(x => x.Tax));

            CreateMap<PropertyTrace, PropertyTraceResponse>()
                       .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                       .ForMember(dest => dest.Value, src => src.MapFrom(x => x.Value))
                       .ForMember(dest => dest.Tax, src => src.MapFrom(x => x.Tax));
        }
    }
}
