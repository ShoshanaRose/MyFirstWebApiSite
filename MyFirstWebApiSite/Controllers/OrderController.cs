using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using DTO;

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        IMapper _mapper;
        IOrderService _orderService;
        public OrderController(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<orderDTO>> Post([FromBody] orderDTO orderDTO)
        {
            Order OrderParse = _mapper.Map<orderDTO, Order>(orderDTO);
            Order newOrder = await _orderService.createNewOrderAsync(OrderParse);
            orderDTO newOrderDTO = _mapper.Map<Order, orderDTO>(newOrder);
            return newOrder != null ? CreatedAtAction(nameof(Get), new { id = newOrder.OrderId }, newOrderDTO) : NoContent();
        }
        //public async Task<ActionResult<Order>> Post([FromBody] orderDTO order)
        //{
        //    try
        //    {
        //        Order orderParse = _mapper.Map<orderDTO, Order>(order);
        //        Order newOrder = await _orderService.createNewOrderAsync(orderParse);
        //        if (newOrder == null)
        //            return BadRequest();
        //        orderDTO orderDto = _mapper.Map<Order, orderDTO>(newOrder);
        //        return CreatedAtAction(nameof(Get), new { id = newOrder.OrderId }, orderDto);
        //    }
        //    catch (Exception e) {
        //        throw new Exception(e.Message);
        //    }
        //}



        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> Get(int id)
        {
            Order order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NoContent();
            return Ok(order);
        }
             
    }
}