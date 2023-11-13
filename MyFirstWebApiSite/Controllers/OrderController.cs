using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MyFirstWebApiSite.Controllers
{
    public class OrderController : Controller
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // POST: OrderController/Create
        [HttpPost]     
        public async Task<Order> Create(Order order)
        {
            return await _orderService.createNewOrder(order);
        }
    }
}
