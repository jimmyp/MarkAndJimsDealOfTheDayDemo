using Microsoft.AspNetCore.Mvc;

namespace MarkAndJimsDealOfTheDay.PlacingOrders
{
    [Produces("application/json")]
    [Route("api/PlaceOrder")]
    public class PlaceOrderController : Controller
    {
        PlaceOrderService _service;

        public PlaceOrderController(PlaceOrderService service)
        {
            _service = service;
        }

        public IActionResult Post(PlaceOrderRequest request)
        {
            if (!PotentialOrder.CanBePlaced(request.customerId, request.productCode, request.quantity))
            {
                return BadRequest(PotentialOrder.GetPlacingErrors(request.customerId, request.productCode, request.quantity));
            }

            _service.PlaceOrder(request.customerId, request.productCode, request.quantity);

            return Ok();
        }
    }
}