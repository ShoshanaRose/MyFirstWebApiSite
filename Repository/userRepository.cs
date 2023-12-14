using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class userRepository : IUserRepository
    {
        private const string filePath = "M:/WEB API/MyFirstWebApiSite/users.txt";

        private MyshopWebApiContext _myshopWebApiContext;
        public userRepository(MyshopWebApiContext myshopWebApiContext)
        {
            _myshopWebApiContext = myshopWebApiContext;
        }

        public async Task<User> getUserByUserNameAndPass(string UserName, string Password)
        {
            return await _myshopWebApiContext.Users.Where(p => p.Email == UserName && p.Password == Password).FirstOrDefaultAsync();
        }

        public async Task<User> getUserById(int id)
        {
            return await _myshopWebApiContext.Users.Where(p => p.UserId == id).FirstOrDefaultAsync();
        }

        public async Task<User> addUser(User user)
        {
            await _myshopWebApiContext.Users.AddAsync(user);
            await _myshopWebApiContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> update(int id, User userToUpdate)
        {
            userToUpdate.UserId = id;//????
            _myshopWebApiContext.Users.Update(userToUpdate);
            await _myshopWebApiContext.SaveChangesAsync();
            return userToUpdate;
        }
    }
}