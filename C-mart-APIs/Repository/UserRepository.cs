using C_mart_APIs.Data;
using C_mart_APIs.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;

namespace C_mart_APIs.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync
                (x => x.Username.ToLower() == username.ToLower() && x.Password == password);
            if(user == null)
            {
                return null;
            }
            var UserRoles = await context.User_Roles.Where(x=>x.UserId==user.Id).ToListAsync();
            if(UserRoles.Any())
            {
                user.Roles = new List<string>();
                foreach(var Role in UserRoles)
                {
                    var role =await context.Roles.FirstOrDefaultAsync(x=>x.Id==Role.Id);
                    if (role != null)
                    {
                        user.Roles.Add(role.Name);
                    }
                }
            }
            user.Password = null;
            return user;
        }
    }
}
