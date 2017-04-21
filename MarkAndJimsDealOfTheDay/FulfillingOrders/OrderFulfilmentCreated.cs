using System;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    public class OrderFulfilmentCreated : IEvent
    {
        public OrderFulfilmentCreated(Guid orderId, string productCode, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}