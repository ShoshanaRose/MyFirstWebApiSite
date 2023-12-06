using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository;

namespace Service
{
    public class OrderService: IOrderService
    {
        private IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> createNewOrder(Order order)
        {
            return await _orderRepository.createNewOrder(order);
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _orderRepository.getOrderById(id);
        }
    }
}
