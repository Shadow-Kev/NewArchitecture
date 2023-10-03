using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewArchitecture.Services.CouponAPI.Features.Coupons.Commands;
using NewArchitecture.Services.CouponAPI.Features.Coupons.Queries;

namespace NewArchitecture.Services.CouponAPI.Features.Coupons;
[Route("api/[controller]")]
[ApiController]
public class CouponController : ControllerBase
{
    private readonly IMediator _mediator;
    public CouponController(IMediator mediator)
    {
        _mediator = mediator;
    }
    /// <summary>
    /// Get All Coupons
    /// </summary>
    /// <returns>Status 200 OK</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCouponsQuery.Query());
        if (result == null)
            return NotFound();

        return Ok(result);
    }
    ///<summary>
    ///Get a Coupon By Id
    ///</summary>
    ///<param name="id"></param>
    ///<returns>Status 200 OK</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetByIdCouponQuery.Query { Id = id });
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(AddOrEditCouponCommand.Command command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var coupon = await _mediator.Send(new DeleteCouponCommand.Command { CouponId = id });
        return Ok(coupon);
    }
}
