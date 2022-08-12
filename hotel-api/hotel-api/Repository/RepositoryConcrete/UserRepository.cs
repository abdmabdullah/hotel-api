using hotel_api.Models;
using hotel_api.Repository.RepositoryInterfaces;
using hotel_api.Utilities;
using Microsoft.EntityFrameworkCore;

namespace hotel_api.Repository.RepositoryConcrete
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private DataContext _dbContext;
        public UserRepository(DataContext context)
        {
            _dbContext = context;
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            User userToDelete = _dbContext.Users.Find(user);
            if (userToDelete == null)
                throw new KeyNotFoundException("User not found");
            _dbContext.Users.Remove(userToDelete);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            User user = _dbContext.Users.Find(id);
            if (user == null)
                throw new KeyNotFoundException("User not found");
            return user;
        }

        public void UpdateUser(User user)
        {
            _dbContext.Entry<User>(user).State = EntityState.Modified;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
