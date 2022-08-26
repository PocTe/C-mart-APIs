using C_mart_APIs.Model;

namespace C_mart_APIs.Repository
{
    public interface IUserRepository
    {
      Task<User> AuthenticateAsync(string username, string password);
    }
}
