using AutoMapper;
using MediatR;
using NewArchitecture.Services.CouponAPI.Domain.Entities;
using NewArchitecture.Services.CouponAPI.ServiceManager;

namespace NewArchitecture.Services.CouponAPI.Features.Coupons.Commands;

public class AddOrEditCouponCommand
{
    public class Command : IRequest<CouponResponse>
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }

    public class CouponResponse
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }

    public class Handler : IRequestHandler<Command, CouponResponse>
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public Handler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<CouponResponse> Handle(Command command, CancellationToken cancellationToken)
        {
            if (command.CouponId == 0)
            {
                var coupon = new Coupon
                {
                    CouponCode = command.CouponCode,
                    DiscountAmount = command.DiscountAmount,
                    MinAmount = command.MinAmount,
                };
                _serviceManager.Coupon.AddCoupon(coupon);
                await _serviceManager.SaveAsync();
                var result = _mapper.Map<CouponResponse>(coupon);
                return result;
            }
            else
            {
                var coupon = await _serviceManager.Coupon.GetByIdAsync(command.CouponId);
                if (coupon == null)
                    throw new Exception("Ce coupon n'existe pas");
                coupon.CouponCode = command.CouponCode;
                coupon.DiscountAmount = command.DiscountAmount;
                coupon.MinAmount = command.MinAmount;
                await _serviceManager.SaveAsync();
                var result = _mapper.Map<CouponResponse>(coupon);
                return result;
            }
        }
    }
}
