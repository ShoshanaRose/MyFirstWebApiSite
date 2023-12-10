using Entities;
using Microsoft.EntityFrameworkCore;
using MyFirstWebApiSite;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private static MyStore20234Context _MyStore20234Context;

        public CategoryRepository(MyStore20234Context myStore20234Context)
        {
            _MyStore20234Context = myStore20234Context;
        }

        public async Task<List<Category>> getCategory()
        {
            return await _MyStore20234Context.Categories.ToListAsync();
        }
    }
}
