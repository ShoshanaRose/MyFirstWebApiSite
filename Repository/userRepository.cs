using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class userRepository : IUserRepository
    {
        private MyshopWebApiContext _myshopWebApiContext;
        public userRepository(MyshopWebApiContext myshopWebApiContext)
        {
            _myshopWebApiContext = myshopWebApiContext;
        }

        public async Task<User> getUserByUserNameAndPassAsync(string UserName, string Password)
        {
            return await _myshopWebApiContext.Users.Where(p => p.Email == UserName && p.Password == Password).FirstOrDefaultAsync();
        }

        public async Task<User> getUserByIdAsync(int id)
        {
            return await _myshopWebApiContext.Users.Where(p => p.UserId == id).FirstOrDefaultAsync();
        }

        public async Task<User> addUserAsync(User user)
        {
            await _myshopWebApiContext.Users.AddAsync(user);
            await _myshopWebApiContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> updateAsync(int id, User userToUpdate)
        {
            userToUpdate.UserId = id;//????
            _myshopWebApiContext.Users.Update(userToUpdate);
            await _myshopWebApiContext.SaveChangesAsync();
            return userToUpdate;
        }
    }
}