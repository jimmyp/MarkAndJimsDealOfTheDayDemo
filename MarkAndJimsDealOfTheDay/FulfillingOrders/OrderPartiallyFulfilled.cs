﻿using System;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    public class OrderPartiallyFulfilled : IEvent
    {
        public int QuantityRequired { get; }
        public Guid Id { get; }

        public OrderPartiallyFulfilled(Guid id, int quantityRequired)
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));
            if (quantityRequired <= 0) throw new ArgumentOutOfRangeException(nameof(quantityRequired));
            Id = id;
            QuantityRequired = quantityRequired;
        }
    }
}