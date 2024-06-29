using AutoMapper;
using Services.CouponAPI.Data.Models;

namespace Services.CouponAPI.Data.Dtos.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Coupon, CouponDto>().ReverseMap();
        }
    }
}
