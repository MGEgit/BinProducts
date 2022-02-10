using BinProducts.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BinProducts.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private Hashtable _orders = new Hashtable();

        public void Save(Order order)
        {
            if (!_orders.ContainsKey(order.Id))
                _orders.Add(order.Id, order);
            else
                throw new DuplicatedIdentityException();
        }

        public Order Get(Guid id)
        {
            if (_orders.ContainsKey(id))
                return (Order)_orders[id];
            else
                return null;
        }
    }
}
