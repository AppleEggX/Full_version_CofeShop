using System.Collections.Generic;
using Pocos;
using Repo;

namespace Services
{
    public class UserService : IUserService
    {
        Model1 model1 = new Model1();

        private IRepository<User> userRepository = new Repository<User>();

        public User CreateUser(User newUser)
        {
            userRepository.CreateNewEntity(newUser);
            return newUser;
        }

        public void DeleteUser(int userId)
        {
            userRepository.DeleteEntity(userId);
        }

        public User EditUser(int userId, User newUser)
        {
            User userToEdit = userRepository.FindById(userId);
            userToEdit.Email = newUser.Email;
            userToEdit.Password = newUser.Password;
            userToEdit.Subscriptions = newUser.Subscriptions;
            userRepository.UpdateEntity(userToEdit);
            return userToEdit;
        }

        public List<User> GetAllUser()
        {
            return userRepository.ReadAll();
        }

        public User GetUserById(int userId)
        {
            return userRepository.FindById(userId);
        }
    }
}
