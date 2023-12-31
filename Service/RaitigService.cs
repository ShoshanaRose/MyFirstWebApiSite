using Repository;
using Entities;

namespace Service
{
    public class RaitigService:IRaitingService
    {
        private IRaitingRepository _raitingRepository;
        public RaitigService(IRaitingRepository raitingRepository)
        {
            _raitingRepository = raitingRepository;
        }
        public async Task<Rating> addRatingAsync(Rating rating)
        {
            return await _raitingRepository.addRatingAsync(rating);
        }
    }
}
