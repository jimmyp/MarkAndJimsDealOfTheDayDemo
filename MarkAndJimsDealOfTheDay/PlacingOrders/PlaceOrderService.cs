using System;

namespace MarkAndJimsDealOfTheDay
{
    public class PlaceOrderService
    {
        private readonly IUow _uow;

        public PlaceOrderService(IUow uow)
        {
            _uow = uow;
        }

        public void PlaceOrder(Guid customerId, string productCode, int quantity)
        {
            var result = PotentialOrder.BuildOrder(customerId, productCode, quantity);

            _uow.Repository.Save(result.Entity);
            _uow.Bus.Publish(result.Event);
            _uow.Commit();
        }
    }
}