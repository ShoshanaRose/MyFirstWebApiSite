using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Service
{
    public interface IOrderService
    {
        Task<Order> createNewOrder(Order order);
    }
}
