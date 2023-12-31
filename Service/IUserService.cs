using Entities;

namespace Service
{
    public interface IUserService
    {
        Task<User> getUserByUserNameAndPassAsync(string userName, string pass);
        Task<User> getUserByIdAsync(int id);
        Task<User> addUserAsync(User user);
        Task<User> updateAsync(int id, User userTUpdate);
        int checkStrongePassword(string pass);
    }
}