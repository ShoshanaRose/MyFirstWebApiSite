using Entities;
using Repository;

namespace Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> getUserByUserNameAndPassAsync(string userName, string pass)
        {
            return await _userRepository.getUserByUserNameAndPassAsync(userName, pass);
        }

        public async Task<User> getUserByIdAsync(int id)
        {
            return await _userRepository.getUserByIdAsync(id);
        }

        public async Task<User> addUserAsync(User user)
        {
            int res = checkStrongePassword(user.Password);
            if (res >= 2)
                return await _userRepository.addUserAsync(user);
            return null;
        }

        public async Task<User> updateAsync(int id, User userToUpdate)
        {
            int res = checkStrongePassword(userToUpdate.Password);
            if (res >= 2)
                return await _userRepository.updateAsync(id, userToUpdate);
            return null;
        }

        public int checkStrongePassword(string pass)
        {
            var result = Zxcvbn.Core.EvaluatePassword(pass);
            return result.Score;
        }

    }
}