using Entities;

namespace Repository
{
    public class RaitingRepository : IRaitingRepository
    {
        private MyshopWebApiContext _myStore20234Context;
        public RaitingRepository(MyshopWebApiContext myStore20234Context)
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
