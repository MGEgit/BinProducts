using BinProducts.Core;
using System;

namespace BinProducts.Application
{
    public interface IOrderApplicationService
    {
        Order Get(Guid id);
        float Handle(AddOrderCommand addOrderCommand);
    }
}
