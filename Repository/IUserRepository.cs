using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> getUserByUserNameAndPassAsync(string UserName, string Password);
        Task<User> getUserByIdAsync(int id);
        Task<User> addUserAsync(User user);
        Task<User> updateAsync(int id, User userToUpdate);
    }
}