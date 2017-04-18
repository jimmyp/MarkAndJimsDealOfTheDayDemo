using System;

namespace MarkAndJimsDealOfTheDay.Controllers
{
    public class PlaceOrderRequest
    {
        public Guid customerId { get; set; }
        public string productCode { get; set; }
        public int quantity { get; set; }
    }
}