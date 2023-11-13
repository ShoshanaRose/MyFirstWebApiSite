using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository
{
    public interface IProductrepository
    {
        Task<List<Product>> getAllProducts();
    }
}
