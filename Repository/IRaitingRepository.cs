using Entities;

namespace Repository
{
    public interface IRaitingRepository
    {
        Task<Rating> addRating(Rating rating);
    }
}
