using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarkAndJimsDealOfTheDay.PlacingOrders;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    public class PotentialOrderPlacedHandler : IHandle<PotentialOrderPlaced>
    {
        private readonly IUow _uow;

        public PotentialOrderPlacedHandler(IUow uow)
        {
            _uow = uow;
        }

        public void Handle(PotentialOrderPlaced evt)
        {
            var result = OrderFullFullfilment.CreateFrom(evt.Id, evt.ProductCode, evt.Quantity);

            _uow.Repository.Save(result.Entity);
            _uow.Bus.Publish(result.Event);
            _uow.Commit();
        }
    }
}
