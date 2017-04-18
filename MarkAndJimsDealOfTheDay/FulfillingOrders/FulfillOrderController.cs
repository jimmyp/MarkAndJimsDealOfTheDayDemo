using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    [Produces("application/json")]
    [Route("api/PlaceOrder")]
    public class FulfillOrderController : Controller
    {
        [HttpPost]
        public IActionResult Post(FullfilOrderRequest request)
        {
            //cut and past in from placed order

        }
    }

    public class FullfilOrderRequest
    {
    }
}
