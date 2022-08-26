using C_mart_APIs.Model;

namespace C_mart_APIs.Repository
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}
