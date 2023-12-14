using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class userRepository : IUserRepository
    {
        private const string filePath = "M:/WEB API/MyFirstWebApiSite/users.txt";

        private MyshopWebApiContext _myStore20234Context;
        public userRepository(MyshopWebApiContext myStore20234Context)
        {
            _myStore20234Context = myStore20234Context;
        }

        public async Task<User> getUserByUserNameAndPass(string UserName, string Password)
        {
            return await _myStore20234Context.Users.Where(p => p.Email == UserName && p.Password == Password).FirstOrDefaultAsync();
        }

        public async Task<User> getUserById(int id)
        {
            return await _myStore20234Context.Users.Where(p => p.UserId == id).FirstOrDefaultAsync();
        }

        public async Task<User> addUser(User user)
        {
            await _myStore20234Context.Users.AddAsync(user);
            await _myStore20234Context.SaveChangesAsync();
            return user;
        }

        public async Task<User> update(int id, User userToUpdate)
        {
            userToUpdate.UserId = id;//????
            _myStore20234Context.Users.Update(userToUpdate);
            await _myStore20234Context.SaveChangesAsync();
            return userToUpdate;
        }
    }
}