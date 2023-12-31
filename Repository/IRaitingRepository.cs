using Entities;

namespace Repository
{
    public interface IRaitingRepository
    {
        Task<Rating> addRatingAsync(Rating rating);
    }
}
