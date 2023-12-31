using Entities;
using Microsoft.Extensions.Logging;
using Repository;

namespace Service
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private ILogger<OrderService> _logger;
        private IProductrepository _productrepository;
        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger, IProductrepository productrepository)
        {
            _orderRepository = orderRepository;
            _logger = logger;
            _productrepository = productrepository;
        }

        public async Task<Order> createNewOrderAsync(Order order)
        {
            //int price = order.OrderSum;
            //int sumPrice = 0;
            //int[] products = new int[order.OrderItems.Count()];
            ////List<OrderItem> orderItems = (List<OrderItem>)order.OrderItems;
            //for (int i = 0; i < order.OrderItems.Count(); i++)
            //{
            //    products[i] = (int)order.OrderItems.ElementAt(i).ProductId;
            //}

            //List<Product> prods = new List<Product>();

            //for (int i = 0; i < products.Length; i++)
            //{
            //    Product p = await _productrepository.getProductByIdAsync(products[i]);
            //    prods.Add(p);
            //}

            //for (int i = 0; i < prods.Count(); i++)
            //{
            //    sumPrice += order.OrderItems.ElementAt(i).Quentity * prods[i].ProdPrice;
            //}

            //if (sumPrice != price)
            //{
            //    _logger.LogError("someone try to create order with not valid order sum");
            //}
            //order.OrderSum = sumPrice;
            //return await _orderRepository.addOrderAsync(order);
            return await _orderRepository.createNewOrderAsync(order);
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.getOrderByIdAsync(id);
        }
    }
}
