using C_mart_APIs.Model;
using Xamarin.Essentials;

namespace C_mart_APIs.Repository
{
    public interface IUserRepository
    {
      Task<User> AuthenticateAsync(string username, string password);
      Task<User> AddAsync(User user);
        Task<User> GetuserAsync(Guid id);
        IEnumerable<User> GetAll();
        
    }
    
}
