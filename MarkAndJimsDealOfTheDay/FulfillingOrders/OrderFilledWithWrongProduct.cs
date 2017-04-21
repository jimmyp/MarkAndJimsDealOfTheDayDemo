using System;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    public class OrderFilledWithWrongProduct : IEvent
    {
        public OrderFilledWithWrongProduct(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}