using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private MyshopWebApiContext _myStore20234Context;
        public OrderRepository(MyshopWebApiContext myStore20234Context)
        {
            _myStore20234Context = myStore20234Context;
        }

        public async Task<Order> createNewOrderAsync(Order order)
        {
            await _myStore20234Context.Orders.AddAsync(order);
            await _myStore20234Context.SaveChangesAsync();
            return order;
        }
        public async Task<Order> getOrderByIdAsync(int id)
        {
            return await _myStore20234Context.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();
        }
    }
}
