using BinProducts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinProducts.Core
{
    public interface IOrderRepository
    {
        Order Get(Guid id);        
        void Save(Order order);
    }
}
