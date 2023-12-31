using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Productrepository : IProductrepository
    {
        private MyshopWebApiContext _myStore20234Context;
        public Productrepository(MyshopWebApiContext myStore20234Context)
        {
            _myStore20234Context = myStore20234Context;
        }

        public async Task<List<Product>> getAllProductsAsync(string? name, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = _myStore20234Context.Products.Where(p =>
            (name == null ? (true) : (p.ProductName.Contains(name)))
            && ((minPrice == null) ? (true) : (p.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (p.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(p.CategoryId))))
                .Include(i => i.Category)
                .OrderBy(p => p.Price);
            List<Product> products = await query.ToListAsync();
            return products;
        }
        public async Task<List<Product>> getAllProductsAsync()
        {
            return await _myStore20234Context.Products.ToListAsync();
        }
    }
}
