using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> createNewOrderAsync(Order order);
        Task<Order> getOrderByIdAsync(int id);
    }
}
