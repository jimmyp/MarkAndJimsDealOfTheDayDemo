using System;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    public class InventoryInWarehouseViewModel
    {
        public InventoryInWarehouseViewModel(Guid id, string description, int aisleNumber)
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));
            if (string.IsNullOrEmpty(description)) throw new ArgumentException(nameof(description));
            if (aisleNumber <= 0) throw new ArgumentOutOfRangeException(nameof(aisleNumber));

            Id = id;
            Description = description;
            AisleNumber = aisleNumber;
        }

        public Guid Id { get; }
        public string Description { get; }
        public int AisleNumber { get; }
    }
}