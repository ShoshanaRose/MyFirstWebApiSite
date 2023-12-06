using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OrderRepository: IOrderRepository
    {
        private MyStore20234Context _myStore20234Context;
        public OrderRepository (MyStore20234Context myStore20234Context)
        {
            _myStore20234Context = myStore20234Context;
        }

        public async Task<Order> createNewOrder(Order order)
        {
            await _myStore20234Context.Orders.AddAsync(order);
            await _myStore20234Context.SaveChangesAsync();
            return order;
        }
        public async Task<Order> getOrderById(int id)
        {
            return await _myStore20234Context.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();
        }
    }
}
