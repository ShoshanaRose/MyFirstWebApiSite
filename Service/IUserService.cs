using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        Task<User> getUserByUserNameAndPass(string userName, int pass);
        Task<User> getUserById(int id);
        Task<User> addUser(User user);
        Task<User> update(int id, User userTUpdate);
        int checkStrongePassword(string pass);
    }
}