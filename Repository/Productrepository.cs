using Entities;
using Microsoft.EntityFrameworkCore;
using MyFirstWebApiSite;

namespace Repository
{
    public class Productrepository : IProductrepository
    {
        private MyStore20234Context _myStore20234Context;
        public Productrepository(MyStore20234Context myStore20234Context)
        {
            _myStore20234Context = myStore20234Context;
        }

        public async Task<List<Product>> getAllProducts(string? name, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = _myStore20234Context.Products.Where(p =>
            (name == null ? (true) : (p.ProductName.Contains(name)))
            && ((minPrice == null) ? (true) : (p.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (p.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(p.CategoryId))))
                .Include(i => i.Category)
                .OrderBy(p => p.Price);
            Console.WriteLine(query.ToQueryString());
            List<Product> products = await query.ToListAsync();
            return products;
        }
        public async Task<List<Product>> getAllProducts()
        {
            return await _myStore20234Context.Products.ToListAsync();
        }
    }
}
