using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> createNewOrder(Order order);
        Task<Order> getOrderById(int id);
    }
}
