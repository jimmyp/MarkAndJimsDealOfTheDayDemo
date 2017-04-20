using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MarkAndJimsDealOfTheDay.FulfillingOrders
{
    [Produces("application/json")]
    [Route("api/PlaceOrder")]
    public class FulfillOrderController : Controller
    {
        private OrderFullFullfilmentService _service;

        [HttpPost]
        public IActionResult Post(FullfilOrderRequest request)
        {

            if (!OrderFullFullfilment.CanBeCreatedFrom(request.OrderId, request.ProductCode, request.Quantity))
            {
                return BadRequest(OrderFullFullfilment.GetCreationErrors(request.OrderId, request.ProductCode, request.Quantity));
            }

            _service.FulfillOrder(request.OrderId, request.ProductCode, request.Quantity);

            return Ok();
        }
    }

    internal class OrderFullFullfilmentService
    {
        private readonly IUow _uow;

        public OrderFullFullfilmentService(IUow uow)
        {
            _uow = uow;
        }

        public void FulfillOrder(Guid orderId, string productCode, int quantity)
        {
            var orderFulfillment = _uow.Repository.Get<OrderFullFullfilment>(orderId);

            var result = orderFulfillment.Fulfillwith(productCode, quantity);

            _uow.Repository.Save(result.Entity);
            _uow.Bus.Publish(result.Event);
            _uow.Commit();
        }
    }

    public class OrderFullFullfilment : IEntity
    {
        public Guid Id { get; set; }
        private Guid orderId;
        private string productCode;
        private int quantityRequired;

        private OrderFullFullfilment(Guid orderId, string productCode, int quantityRequired)
        {
            if(!CanBeCreatedFrom(orderId, productCode, quantityRequired)) throw new Exception("You dun @#$% Up.");
            this.Id = new Guid();
            this.orderId = orderId;
            this.productCode = productCode;
            this.quantityRequired = quantityRequired;
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

        public DomainOperationResult Fulfillwith(string productCode, int quantity)
        {
            if (productCode != this.productCode)
                return new DomainOperationResult(this, new OrderFilledWithWrongProduct(Id));

            if (quantity > this.quantityRequired)
                return new DomainOperationResult(this, new OrderOverFilled(Id, quantity));

            if (quantity < this.quantityRequired)
            {
                quantityRequired -= quantity;
                return new DomainOperationResult(this, new OrderPartiallyFulfilled(Id, quantityRequired));
            }

            return new DomainOperationResult(this, new OrderFilled(Id));
        }
    }

    public class OrderFilled : IEvent
    {
        public Guid Id { get; }

        public OrderFilled(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));

            Id = id;
        }
    }

    public class OrderPartiallyFulfilled : IEvent
    {
        public int QuantityRequired { get; }
        public Guid Id { get; }

        public OrderPartiallyFulfilled(Guid id, int quantityRequired)
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));
            if (quantityRequired <= 0) throw new ArgumentOutOfRangeException(nameof(quantityRequired));
            Id = id;
            quantityRequired = quantityRequired;
        }
    }

    public class OrderOverFilled : IEvent
    {
        public Guid Id { get; }
        public int Quantity { get; }

        public OrderOverFilled(Guid id, int quantity)
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

            Id = id;
            Quantity = quantity;
        }
    }

    public class OrderFilledWithWrongProduct : IEvent
    {
        public OrderFilledWithWrongProduct(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class OrderFulfilmentCreated : IEvent
    {
        public OrderFulfilmentCreated(Guid orderId, string productCode, int quantity)
        {
            throw new NotImplementedException();
        }
    }

    public class FullfilOrderRequest
    {
        public Guid OrderId { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}
