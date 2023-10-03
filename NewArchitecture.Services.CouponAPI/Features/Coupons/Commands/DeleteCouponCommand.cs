using AutoMapper;
using MediatR;
using NewArchitecture.Services.CouponAPI.ServiceManager;

namespace NewArchitecture.Services.CouponAPI.Features.Coupons.Commands;

public class DeleteCouponCommand
{
    public class Command : IRequest<Unit>
    {
        public int CouponId { get; set; }
    }

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IServiceManager _serviceManager;

        public Handler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
        {
            var coupon = await _serviceManager.Coupon.GetByIdAsync(command.CouponId);
            if (coupon == null)
                throw new Exception("Ce coupon n'existe pas");
            _serviceManager.Coupon.DeleteCoupon(coupon);
            await _serviceManager.SaveAsync();
            return Unit.Value;
        }
    }

}
