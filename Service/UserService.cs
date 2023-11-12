using Entities;
using Repository;

namespace Service
{
    public class UserService:IUserService
    {
        private IUserRepository _userRepository ;
        //userRepository userRepository = new userRepository();
        
        public async Task<User> getUserByUserNameAndPass(string userName, int pass)
        {
            return await _userRepository.getUserByUserNameAndPass(userName, pass);
        }

        public async Task<User> getUserById(int id)
        {
            return await _userRepository.getUserById(id);
        }

        public User addUser(User user)
        {
            //int res = checkStrongePassword(user.Password);
            //if (res >= 2)
            //    return userRepository.addUser(user);
            //else
            return null;
        }

        public async Task<User> update(int id, User userTUpdate)
        {
            //int res = checkStrongePassword(userTUpdate.Password);
            //if(res>=2)
            //    return await userRepository.update(id, userTUpdate);
           return null;
        }

        public int checkStrongePassword(string pass)
        {
            var result = Zxcvbn.Core.EvaluatePassword(pass);
            return  result.Score;
        }

    }
}
