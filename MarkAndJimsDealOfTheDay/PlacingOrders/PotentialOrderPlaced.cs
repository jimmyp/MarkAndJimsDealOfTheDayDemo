using System;

namespace MarkAndJimsDealOfTheDay.PlacingOrders
{
    public class PotentialOrderPlaced : IEvent
    {
        public string ProductCode { get; }
        public Guid Id { get; }
        public int Quantity { get; set; }
    }
}