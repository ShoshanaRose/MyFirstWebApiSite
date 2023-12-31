using Entities;

namespace Service
{
    public interface IOrderService
    {
        Task<Order> createNewOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(int id);
    }
}
