    using System;
using System.Collections.Generic;
using System.Linq;
using MarkAndJimsDealOfTheDay.PlacingOrders;

namespace MarkAndJimsDealOfTheDay.Controllers
{
    public class PotentialOrder : IEntity
    {
        public Guid CustomerId { get; }
        public string ProductCode { get; }
        public int Quantity { get; }

        private PotentialOrder(Guid customerId, string productCode, int quantity)
        {
            if (!CanBePlaced(customerId, productCode, quantity)) throw new Exception("You dun @#$% Up.");

            CustomerId = customerId;
            ProductCode = productCode;
            Quantity = quantity;
        }

        public static DomainOperationResult BuildOrder(Guid customerId, string productCode, int quantity)
        {
            return new DomainOperationResult(new PotentialOrder(customerId, productCode, quantity), new PotentialOrderPlaced());
        }

        public static bool CanBePlaced(Guid customerId, string productCode, int quantity)
        {
            return GetPlacingErrors(customerId, productCode, quantity).Count() > 1;
        }

        public static IEnumerable<string> GetPlacingErrors(Guid customerId, string productCode, int quantity)
        {
            var errors = new List<string>();
            if (customerId == Guid.Empty) errors.Add("Customer id is empty");
            if (string.IsNullOrEmpty(productCode)) errors.Add("Product code is empty");
            if (quantity < 1) errors.Add("Must order at least one widget");
            return errors;
        }
    }
}