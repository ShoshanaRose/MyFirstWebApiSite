using Entities;
using MyFirstWebApiSite;

namespace Repository
{
    public class RaitingRepository:IRaitingRepository
    {
        private MyStore20234Context _myStore20234Context;
        public RaitingRepository(MyStore20234Context myStore20234Context)
        {
            _myStore20234Context = myStore20234Context;
        }

        public async Task<Rating> addRating(Rating rating)
        {          
            await _myStore20234Context.Ratings.AddAsync(rating);
            await _myStore20234Context.SaveChangesAsync();
            return rating;         
        }
    }
}
