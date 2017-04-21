using System;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
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