using BinProducts.Core;
using System;
using System.Collections.Generic;

namespace BinProducts.Application
{
    public class OrderApplicationService : IOrderApplicationService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderApplicationService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Get(Guid id)
        {
            return _orderRepository.Get(id);
        }

        public float Handle(AddOrderCommand addOrderCommand)
        {
            var order = new Order(addOrderCommand.OrderId, addOrderCommand.Items);

            _orderRepository.Save(order);

            return order.RequiredBinWidth;
        }
    }
}
