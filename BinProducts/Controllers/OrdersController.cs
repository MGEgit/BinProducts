using BinProducts.Application;
using BinProducts.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BinProducts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {

        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderApplicationService _orderApplicationService;

        public OrdersController(ILogger<OrdersController> logger, IOrderApplicationService orderApplicationService)
        {
            _logger = logger;
            _orderApplicationService = orderApplicationService;
        }

        [HttpGet("{id}")]
        public Order Get(Guid id)
        {
            return _orderApplicationService.Get(id);
        }

        [HttpPost]
        public float Post([FromBody] AddOrderCommand addOrderCommand)
        {
            return _orderApplicationService.Handle(addOrderCommand);
        }
    }
}
