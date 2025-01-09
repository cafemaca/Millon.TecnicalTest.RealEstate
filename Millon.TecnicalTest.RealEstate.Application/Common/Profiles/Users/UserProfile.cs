// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="UsuarioProfile.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using AutoMapper;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Users;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Users;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Profiles.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateRequest, Usuario>()
                       .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                       .ForMember(dest => dest.Nombre, src => src.MapFrom(x => x.Nombre))
                       .ForMember(dest => dest.Telefono, src => src.MapFrom(x => x.Telefono))
                       .ForMember(dest => dest.Direccion, src => src.MapFrom(x => x.Direccion));

            CreateMap<UserUpdateRequest, Usuario>()
                       .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                       .ForMember(dest => dest.Nombre, src => src.MapFrom(x => x.Nombre))
                       .ForMember(dest => dest.Telefono, src => src.MapFrom(x => x.Telefono))
                       .ForMember(dest => dest.Direccion, src => src.MapFrom(x => x.Direccion));

            CreateMap<Usuario, UserResponse>()
                       .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                       .ForMember(dest => dest.Nombre, src => src.MapFrom(x => x.Nombre))
                       .ForMember(dest => dest.Telefono, src => src.MapFrom(x => x.Telefono))
                       .ForMember(dest => dest.Direccion, src => src.MapFrom(x => x.Direccion));

        }
    }
}
