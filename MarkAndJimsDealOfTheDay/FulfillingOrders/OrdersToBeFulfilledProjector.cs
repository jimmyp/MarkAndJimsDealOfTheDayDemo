using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarkAndJimsDealOfTheDay.PlacingOrders;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    public class OrdersToBeFulfilledProjector : IHandle<PotentialOrderPlaced>
    {
        private IRepository _readModelRepository;

        public OrdersToBeFulfilledProjector(IRepository readModelRepository)
        {
            _readModelRepository = readModelRepository;
        }

        public void Handle(PotentialOrderPlaced evt)
        {
            var rm = _readModelRepository.Get<InventoryInWarehouseViewModel>(evt.ProductCode);
            var vm = new OrderToBeFulfilledViewModel(evt.Id, evt.ProductCode, rm.Description, rm.AisleNumber, evt.Quantity);
            _readModelRepository.Save(vm);
        }
    }
}
