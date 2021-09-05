using System.Collections.Generic;
using System.Threading.Tasks;
using core.Entities;

namespace Services
{
    public interface IUserService
    {
        bool Login(string username, string password);
        Task Register(User user); 
        Task<User> UpdateUser(User user);
        Task DeleteUser(long userId);
        Task<User> GetUserById(long userId);
        IEnumerable<User> Search(User user);
        IEnumerable<User> GetFriends(long userId); 
    }
}