using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinProducts.Core
{
    public class Order
    {
        public Guid Id { get; private set; }

        public IEnumerable<OrderItem> Items { get; private set; }
        public float RequiredBinWidth { get; private set; }

        public Order(Guid id, IEnumerable<OrderItem> items)
        {
            Id = id;

            if (items.GroupBy(i => i.ProductType).Any(g => g.Count() > 1))
                throw new DomainException("duplicated product type.");

            Items = new List<OrderItem>(items);
            RequiredBinWidth = items.Sum(o => o.RequiredBinWidth);
        }
    }
}
