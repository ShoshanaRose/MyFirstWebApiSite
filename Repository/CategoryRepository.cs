using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private static MyshopWebApiContext _MyStore20234Context;

        public CategoryRepository(MyshopWebApiContext myStore20234Context)
        {
            _MyStore20234Context = myStore20234Context;
        }

        public async Task<List<Category>> getCategoryAsync ()
        {
            return await _MyStore20234Context.Categories.ToListAsync();
        }
    }
}
