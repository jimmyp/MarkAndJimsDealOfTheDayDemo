using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    public class InventoryProjector : IHandle<InventoryPlacedInWarehouse>
    {
        private readonly IRepository _readModelRepo;

        public InventoryProjector(IRepository readModelRepo)
        {
            _readModelRepo = readModelRepo;
        }

        public void Handle(InventoryPlacedInWarehouse evt)
        {
            var vm = new InventoryInWarehouseViewModel(evt.Id, evt.Description, evt.AisleNumber);
            _readModelRepo.Save(vm);
        }
    }
}
