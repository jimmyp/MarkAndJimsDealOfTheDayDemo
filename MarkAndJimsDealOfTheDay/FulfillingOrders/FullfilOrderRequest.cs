using System;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    public class FullfilOrderRequest
    {
        public Guid OrderId { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}