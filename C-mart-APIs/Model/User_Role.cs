using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace C_mart_APIs.Model
{
    public class User_Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        public User User  { get; set; } //navigation property for user
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RoleId{ get; set; }
        public Role Role { get; set; }
    }
}
