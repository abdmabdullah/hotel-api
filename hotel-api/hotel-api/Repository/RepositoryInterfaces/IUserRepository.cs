using hotel_api.Models;

namespace hotel_api.Repository.RepositoryInterfaces
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user); 
    }
}
