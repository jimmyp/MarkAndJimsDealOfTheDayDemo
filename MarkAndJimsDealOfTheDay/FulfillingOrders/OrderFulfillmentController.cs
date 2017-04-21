using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    public class OrderFulfillmentController : Controller
    {
        private readonly IRepository _readmodelRepo;

        public OrderFulfillmentController(IRepository readmodelRepo)
        {
            _readmodelRepo = readmodelRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_readmodelRepo.GetAll<OrderToBeFulfilledViewModel>());
        }
    }
}
