namespace C_mart_APIs.Model
{
    public class User_Role
    {   
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User  { get; set; } //navigation property for user
        public Guid RoleId{ get; set; }
        public Role Role { get; set; }
    }
}
