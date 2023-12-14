using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> getUserByUserNameAndPass(string UserName, string Password);
        Task<User> getUserById(int id);
        Task<User> addUser(User user);
        Task<User> update(int id, User userToUpdate);
    }
}