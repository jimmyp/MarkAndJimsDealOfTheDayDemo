using System;

namespace MarkAndJimsDealOfTheDay.PlacingOrders
{
    public class PlaceOrderRequest
    {
        public Guid customerId { get; set; }
        public string productCode { get; set; }
        public int quantity { get; set; }
    }
}