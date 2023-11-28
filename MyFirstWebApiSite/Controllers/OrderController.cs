using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // POST: OrderController/Create
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            return await _orderService.createNewOrder(order);
            //try {
            //    Order newOrder = await _orderService.createNewOrder(order);
            //    if (newOrder == null)
            //        return BadRequest();
            //    return CreatedAtAction(nameof(Get), new { id = order.OrderId }, newOrder);
            //}
            //catch(Exception e){
            //    throw e;
            //}
        }
    }
}