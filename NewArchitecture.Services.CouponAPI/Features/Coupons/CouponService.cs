using Microsoft.EntityFrameworkCore;
using NewArchitecture.Services.CouponAPI.Data;
using NewArchitecture.Services.CouponAPI.Domain.Entities;

namespace NewArchitecture.Services.CouponAPI.Features.Coupons;

public class CouponService : ICouponService
{
    private readonly AppDbContext _context;

    public CouponService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Coupon>> GetAllAsync()
    {
        return await _context.Coupons.ToListAsync();
    }

    public async Task<Coupon> GetByIdAsync(int couponId)
    {
        return await _context.Coupons.FirstOrDefaultAsync(c => c.CouponId == couponId);
    }

    public void AddCoupon(Coupon coupon)
    {
        _context.Add(coupon);
    }

    public void DeleteCoupon(Coupon coupon)
    {
        _context.Remove(coupon);
    }
}
