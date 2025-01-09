using AutoMapper;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Audit;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Domain.Entities.Audit;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Profiles.Audit
{
    public class PagedListAuditTrailProfile : Profile
    {
        public PagedListAuditTrailProfile()
        {
            CreateMap<PagedList<AuditTrail>, PagedList<AuditTrailResponse>>()
                       .ForMember(dest => dest.PageSize, src => src.MapFrom(x => x.PageSize))
                       .ForMember(dest => dest.CurrentPage, src => src.MapFrom(x => x.CurrentPage))
                       .ForMember(dest => dest.TotalItemCount, src => src.MapFrom(x => x.TotalItemCount))
                       .ForMember(dest => dest.TotalPageCount, src => src.MapFrom(x => x.TotalPageCount))
                       .ForMember(dest => dest.Items, src => src.MapFrom(x => x.Items));

        }
    }
}
