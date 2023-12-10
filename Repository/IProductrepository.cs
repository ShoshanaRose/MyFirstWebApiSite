using Entities;

namespace Repository
{
    public interface IProductrepository
    {
        Task<List<Product>> getAllProducts(string? description, int? minPrice, int? maxPrice, int?[] categoryIds);
        Task<List<Product>> getAllProducts();
    }
}
