using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    internal class OrderFullFullfilmentService
    {
        private readonly IUow _uow;

        public OrderFullFullfilmentService(IUow uow)
        {
            _uow = uow;
        }
    }
}
