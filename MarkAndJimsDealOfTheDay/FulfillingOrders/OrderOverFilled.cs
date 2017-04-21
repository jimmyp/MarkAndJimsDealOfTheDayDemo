using System;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    public class OrderOverFilled : IEvent
    {
        public Guid Id { get; }
        public int Quantity { get; }

        public OrderOverFilled(Guid id, int quantity)
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

            Id = id;
            Quantity = quantity;
        }
    }
}