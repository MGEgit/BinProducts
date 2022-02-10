using BinProducts.Core;
using System;
using System.Collections.Generic;

namespace BinProducts.Application
{
    public class AddOrderCommand
    {
        public Guid OrderId { get; set; }

        public IEnumerable<OrderItem> Items { get; set; }
    }
}