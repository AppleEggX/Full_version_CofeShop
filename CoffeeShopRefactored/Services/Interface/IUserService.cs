using System.Collections.Generic;
using Pocos;

namespace Services
{
    interface IUserService
    {
        List<User> GetAllUser();
        User GetUserById(int userId);
        void DeleteUser(int userId);
        User EditUser(int userId, User newUser);
        User CreateUser(User newUser);
        
    }
}
