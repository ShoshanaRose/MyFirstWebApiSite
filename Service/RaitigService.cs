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
        public async Task<Rating> addRating(Rating rating)
        {
            return await _raitingRepository.addRating(rating);
        }
    }
}
