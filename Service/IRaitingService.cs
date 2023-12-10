using Entities;

namespace Service
{
    public interface IRaitingService
    {
        Task<Rating> addRating(Rating rating);
    }
}
