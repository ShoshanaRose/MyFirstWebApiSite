using Entities;
using Repository;

namespace Service
{
    public class ProductService : IProductService
    {
        private IProductrepository _productrepository;
        public ProductService(IProductrepository productrepository)
        {
            _productrepository = productrepository;
        }

        public async Task<List<Product>> getAllProductsAsync(string? description, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await _productrepository.getAllProductsAsync(description, minPrice, maxPrice, categoryIds);
        }
    }
}