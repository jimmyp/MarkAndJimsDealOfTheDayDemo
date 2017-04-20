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
        private readonly IRepository _readModelRepository;

        public OrdersToBeFulfilledController(IRepository readModelRepository)
        {
            _readModelRepository = readModelRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_readModelRepository.GetAll<OrderToBeFulfilledViewModel>());
        }
    }
}
