using AutoMapper;
using MediatR;
using NewArchitecture.Services.CouponAPI.ServiceManager;

namespace NewArchitecture.Services.CouponAPI.Features.Coupons.Queries;

public class GetByIdCouponQuery
{
    public class Query : IRequest<CouponResponse>
    {
        public int Id { get; set; }
    }

    public class CouponResponse
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }

    public class Handler : IRequestHandler<Query, CouponResponse>
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;
        public Handler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<CouponResponse> Handle(Query query, CancellationToken cancellationToken)
        {
            var coupon = await _serviceManager.Coupon.GetByIdAsync(query.Id);
            var result = _mapper.Map<CouponResponse>(coupon);
            return result;
            
        }
    }
}
