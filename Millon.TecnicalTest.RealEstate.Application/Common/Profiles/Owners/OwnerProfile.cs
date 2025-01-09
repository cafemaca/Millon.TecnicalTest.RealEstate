// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-09-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-09-2025
//  ****************************************************************
//  <copyright file="DepartamentoRequest.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using AutoMapper;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Owners;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Owners;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Profiles.Owners
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<OwnerCreateRequest, Owner>()
                       .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                       .ForMember(dest => dest.Address, src => src.MapFrom(x => x.Address))
                       .ForMember(dest => dest.Photo, src => src.MapFrom(x => x.Photo))
                       .ForMember(dest => dest.Birthday, src => src.MapFrom(x => x.Birthday));

            CreateMap<OwnerUpdateRequest, Owner>()
                       .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                       .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                       .ForMember(dest => dest.Address, src => src.MapFrom(x => x.Address))
                       .ForMember(dest => dest.Photo, src => src.MapFrom(x => x.Photo))
                       .ForMember(dest => dest.Birthday, src => src.MapFrom(x => x.Birthday));

            CreateMap<Owner, OwnerResponse>()
                       .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                       .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                       .ForMember(dest => dest.Address, src => src.MapFrom(x => x.Address))
                       .ForMember(dest => dest.Photo, src => src.MapFrom(x => x.Photo))
                       .ForMember(dest => dest.Birthday, src => src.MapFrom(x => x.Birthday));

        }
    }
}
