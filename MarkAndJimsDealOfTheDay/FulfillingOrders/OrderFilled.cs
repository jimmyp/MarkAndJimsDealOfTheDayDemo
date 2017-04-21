using System;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    public class OrderFilled : IEvent
    {
        public Guid Id { get; }

        public OrderFilled(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));

            Id = id;
        }
    }
}