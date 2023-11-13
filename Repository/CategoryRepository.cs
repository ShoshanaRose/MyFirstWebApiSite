using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CategoryRepository: ICategoryRepository
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
