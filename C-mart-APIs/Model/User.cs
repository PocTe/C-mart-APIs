using System.ComponentModel.DataAnnotations.Schema;

namespace C_mart_APIs.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string lastname { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public List<string> Roles { get; set; }
       public List<User_Role> User_Roles { get; set; }
    }
}
