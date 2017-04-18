using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    [Produces("application/json")]
    [Route("api/PlaceOrder")]
    public class OrdersToBeFulfilledController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_readModel.GetAll<OrderToBeFulfilledViewModel>());
        }
    }
}
