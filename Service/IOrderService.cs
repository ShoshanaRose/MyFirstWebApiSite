using Entities;

namespace Service
{
    public interface IOrderService
    {
        Task<Order> createNewOrder(Order order);
        Task<Order> GetOrderById(int id);
    }
}
