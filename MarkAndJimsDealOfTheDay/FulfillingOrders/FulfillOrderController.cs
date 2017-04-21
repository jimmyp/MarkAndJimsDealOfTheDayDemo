using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    [Produces("application/json")]
    [Route("api/PlaceOrder")]
    public class FulfillOrderController : Controller
    {
        private OrderFullFullfilmentService _service;

        [HttpPost]
        public IActionResult Post(FullfilOrderRequest request)
        {

            if (!OrderFullFullfilment.CanBeCreatedFrom(request.OrderId, request.ProductCode, request.Quantity))
            {
                return BadRequest(OrderFullFullfilment.GetCreationErrors(request.OrderId, request.ProductCode, request.Quantity));
            }

            _service.FulfillOrder(request.OrderId, request.ProductCode, request.Quantity);

            return Ok();
        }
    }
}
