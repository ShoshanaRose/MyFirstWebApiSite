using Entities;
using Repository;

namespace Service
{
    public class UserService:IUserService
    {
        private IUserRepository _userRepository ;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> getUserByUserNameAndPass(string userName, int pass)
        {
            return await _userRepository.getUserByUserNameAndPass(userName, pass);
        }

        public async Task<User> getUserById(int id)
        {
            return await _userRepository.getUserById(id);
        }

        public async Task<User> addUser(User user)
        {
            return await _userRepository.addUser(user);
        }

        public async Task<User> update(int id, User userTUpdate)
        {
            return await _userRepository.update(id, userTUpdate);
        }

        public int checkStrongePassword(string pass)
        {
            var result = Zxcvbn.Core.EvaluatePassword(pass);
            return  result.Score;
        }

    }
}
