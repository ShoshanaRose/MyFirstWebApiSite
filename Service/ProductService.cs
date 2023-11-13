using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository;

namespace Service
{
    public class ProductService: IProductService
    {
        private IProductrepository _productrepository;
        public ProductService(IProductrepository productrepository)
        {
            _productrepository = productrepository;
        }

        public async Task<List<Product>> getAllProducts()
        {
            return await _productrepository.getAllProducts();
        }
    }
}