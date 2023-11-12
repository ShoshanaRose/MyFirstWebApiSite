using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> getUserByUserNameAndPass(string UserName, int Password);
        Task<User> getUserById(int id);
        User addUser(User user);
        Task<User> update(int id, User userTUpdate);


    }
}
