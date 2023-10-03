using AutoMapper;
using NewArchitecture.Services.CouponAPI.Domain.Entities;
using NewArchitecture.Services.CouponAPI.Features.Coupons.Commands;
using NewArchitecture.Services.CouponAPI.Features.Coupons.Queries;

namespace NewArchitecture.Services.CouponAPI.Features.Coupons;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Coupon, GetAllCouponsQuery.CouponResponse>();
        CreateMap<Coupon, GetByIdCouponQuery.CouponResponse>();
        CreateMap<Coupon, AddOrEditCouponCommand.CouponResponse>();
    }
}
