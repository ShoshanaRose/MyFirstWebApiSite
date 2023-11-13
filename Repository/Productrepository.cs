using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Productrepository:IProductrepository
    {
        private MyStore20234Context _myStore20234Context;
        public Productrepository(MyStore20234Context myStore20234Context)
        {
            _myStore20234Context = myStore20234Context;
        }

        public async Task<List<Product>> getAllProducts()
        {
            return await _myStore20234Context.Products.ToListAsync();
        }

    }
}
