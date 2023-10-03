using AutoMapper;
using MediatR;
using NewArchitecture.Services.CouponAPI.ServiceManager;

namespace NewArchitecture.Services.CouponAPI.Features.Coupons.Queries;

public class GetAllCouponsQuery
{
    public class Query : IRequest<IEnumerable<CouponResponse>> { }

    public class CouponResponse
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }

    public class Handler : IRequestHandler<Query, IEnumerable<CouponResponse>>
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public Handler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CouponResponse>> Handle(Query query, CancellationToken cancellationToken)
        {
            var coupons = await _serviceManager.Coupon.GetAllAsync();
            var results = _mapper.Map<IEnumerable<CouponResponse>>(coupons);
            return results;
        }
    }
}
