﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> createNewOrder(Order order);
        Task<Order> getOrderById(int id);
    }
}
