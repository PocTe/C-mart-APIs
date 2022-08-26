using C_mart_APIs.Model;

namespace C_mart_APIs.Repository
{
    public class StaticUserRepository : IUserRepository
    {
        private List<User> Users = new List<User>
        {
            //new User(){
            //Id =Guid.NewGuid(),
            //Username ="ReadWrite@user.com",
            //Password="readwrite@user",
            //Firstname="Anshu",
            //lastname="abc",
            //Email="abc@gmail.com",
            //Roles = new List<string> { "reader" ,"writer" }
            //}

        };
        public async  Task<User> AuthenticateAsync(string username, string password)
        {
           var user= Users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
            x.Password == password);
            
            return user;
            
        }
    }
}
