using System;
using MarkAndJimsDealOfTheDay.PlacingOrders;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    //snippet
    public class InventoryProjection : IHandle<InventoryPlacedInWarehouse>
    {
        private readonly IRepository _readModelRepository;

        public InventoryProjection(IRepository readModelRepository)
        {
            _readModelRepository = readModelRepository;
        }

        public void Handle(InventoryPlacedInWarehouse evt)
        {
            var vm = new InventoryInWarehouseViewModel(evt.Id, evt.Description, evt.AisleNumber);
            _readModelRepository.Save(vm);
        }
    }

    public class InventoryInWarehouseViewModel
    {
        public InventoryInWarehouseViewModel(Guid id, string description, int aisleNumber)
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));
            if (string.IsNullOrEmpty(description)) throw new ArgumentException(nameof(description));
            if (aisleNumber <= 0) throw new ArgumentOutOfRangeException(nameof(aisleNumber));

            Id = id;
            Description = description;
            AisleNumber = aisleNumber;
        }

        public Guid Id { get; }
        public string Description { get; }
        public int AisleNumber { get; }
    }

    public class InventoryPlacedInWarehouse
    {
        public Guid Id { get; }
        public string Description { get; }
        public int AisleNumber { get; }
    }

    //live
    public class OrdersToBeFulfilledProjector : IHandle<PotentialOrderPlaced>
    {
        private readonly IRepository _readModelRepository;

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

    public class OrderToBeFulfilledViewModel
    {
        public Guid Id { get; }
        public string ProductCode { get; }
        public string Description { get; }
        public int AisleNum { get; }
        public int Quanity { get; }

        public OrderToBeFulfilledViewModel(Guid id, string productCode, string description, int aisleNum, int quanity)
        {
            if (id == Guid.Empty) throw new ArgumentOutOfRangeException(nameof(id));
            if (string.IsNullOrEmpty(productCode)) throw new ArgumentException(nameof(productCode));
            if (string.IsNullOrEmpty(description)) throw new ArgumentException(nameof(description));
            if (aisleNum <= 0) throw new ArgumentOutOfRangeException(nameof(aisleNum));
            if (quanity <= 0) throw new ArgumentOutOfRangeException(nameof(quanity));

            Id = id;
            ProductCode = productCode;
            Description = description;
            AisleNum = aisleNum;
            Quanity = quanity;
        }
    }
}
