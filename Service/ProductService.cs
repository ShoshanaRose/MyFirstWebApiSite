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

        public async Task<List<Product>> getAllProducts(string? description, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            //List<Product> products = await _productrepository.getAllProducts(desc, minPrice, maxPrice, categoryIds);
            //return products != null ? products : null;
            return await _productrepository.getAllProducts(description, minPrice, maxPrice, categoryIds);
        }

        public async Task<List<Product>> getAllProducts()
        {
            return await _productrepository.getAllProducts();
        }
    }
}