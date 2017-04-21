using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    public class OrderFullFullfilment : IEntity
    {
        private readonly Guid _id;
        private readonly string _productCode;
        private int _quantityNeededToFill;

        private OrderFullFullfilment(Guid orderId, string productCode, int quantityNeededToFill)
        {
            if(!CanBeCreatedFrom(orderId, productCode, quantityNeededToFill)) throw new Exception("You dun @#$% Up.");
            _id = orderId;
            _productCode = productCode;
            _quantityNeededToFill = quantityNeededToFill;
        }


        public static bool CanBeCreatedFrom(Guid orderId, string productCode, int quantity)
        {
            return GetCreationErrors(orderId, productCode, quantity).Any();
        }

        public static IEnumerable<string> GetCreationErrors(Guid orderId, string productCode, int quantity)
        {
            var errors = new List<string>();
            if (orderId == Guid.Empty) errors.Add("Customer id is empty");
            if (string.IsNullOrEmpty(productCode)) errors.Add("Product code is empty");
            if (quantity < 1) errors.Add("Must be fullfilling with at least one widget");
            return errors;
        }

        public static DomainOperationResult CreateFrom(Guid orderId, string productCode, int quantity)
        {
            return new DomainOperationResult(new OrderFullFullfilment(orderId, productCode, quantity), new OrderFulfilmentCreated(orderId, productCode, quantity));
        }
        
    }
}