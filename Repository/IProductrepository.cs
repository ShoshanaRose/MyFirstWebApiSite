using Entities;

namespace Repository
{
    public interface IProductrepository
    {
        Task<List<Product>> getAllProductsAsync(string? description, int? minPrice, int? maxPrice, int?[] categoryIds);
        Task<List<Product>> getAllProductsAsync();
    }
}
