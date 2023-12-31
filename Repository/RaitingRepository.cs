using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Repository
{
    public class RaitingRepository : IRaitingRepository
    {
        private MyshopWebApiContext _myStore20234Context;
        //IConfiguration _configuration;
        public RaitingRepository(MyshopWebApiContext myStore20234Context)
        {
            _myStore20234Context = myStore20234Context;
        }
        //public RaitingRepository(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public async Task<Rating> addRatingAsync(Rating rating)
        {
            await _myStore20234Context.Ratings.AddAsync(rating);
            await _myStore20234Context.SaveChangesAsync();
            return rating;
        }
    }
}
