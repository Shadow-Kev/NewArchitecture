using NewArchitecture.Services.CouponAPI.Domain.Entities;

namespace NewArchitecture.Services.CouponAPI.Features.Coupons;

public interface ICouponService
{
    Task<IEnumerable<Coupon>> GetAllAsync();
    Task<Coupon> GetByIdAsync(int couponId);
    void AddCoupon(Coupon coupon);
    void DeleteCoupon(Coupon coupon);
}
