using Entities;

namespace Service
{
    public interface IProductService
    {
        Task<List<Product>> getAllProductsAsync(string? description, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}
