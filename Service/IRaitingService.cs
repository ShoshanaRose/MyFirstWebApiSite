using Entities;

namespace Service
{
    public interface IRaitingService
    {
        Task<Rating> addRatingAsync(Rating rating);
    }
}
