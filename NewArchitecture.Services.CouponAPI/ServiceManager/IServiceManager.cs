using NewArchitecture.Services.CouponAPI.Features.Coupons;

namespace NewArchitecture.Services.CouponAPI.ServiceManager;

public interface IServiceManager
{
    ICouponService Coupon {  get; }
    Task SaveAsync();
}
