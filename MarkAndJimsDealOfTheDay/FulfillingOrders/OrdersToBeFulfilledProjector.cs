using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarkAndJimsDealOfTheDay.Controllers;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    //snippet
    public class InventoryProjection : IHandle<InventoryPlacedInWarehouse>
    {
        public void Handle(InventoryPlacedInWarehouse evt)
        {
            var vm = new InventoryInWarehouse(evt);
            _readModel.Save(vm);
        }
    }

    //live
    public class OrdersToBeFulfilledProjector : IHandle<PotentialOrderPlaced>
    {
        public void Handle(PotentialOrderPlaced evt)
        {
            var rm = _readModel.Get(evt.ProductCode);
            var vm = new OrderToBeFulfilledViewModel(evt.Id, evt.ProductCode, rm.Description, rm.AisleNumber, evt.Quantity);
            _readModel.Save(vm);
        }
    }

    public class OrderToBeFulfilledViewModel
    {
        public OrderToBeFulfilledViewModel(int id, string productCode, string description, int aisleNum, int quanity)
        {
            throw new NotImplementedException();
        }
    }
}
