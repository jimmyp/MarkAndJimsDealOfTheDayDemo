using System;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    public class InventoryPlacedInWarehouse : IEvent
    {
        public Guid Id { get; }
        public string Description { get; }
        public int AisleNumber { get; }
    }
}