using NewArchitecture.Services.CouponAPI.Data;
using NewArchitecture.Services.CouponAPI.Features.Coupons;

namespace NewArchitecture.Services.CouponAPI.ServiceManager;

public class ServiceManager : IServiceManager
{
    private readonly AppDbContext _context;
    private ICouponService _couponService;

    public ServiceManager(AppDbContext context)
    {
        _context = context;
    }
    public ICouponService Coupon
    {
        get
        {
            if ( _couponService == null )
                _couponService = new CouponService( _context);
            return _couponService;
        }
    }
    public Task SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}
