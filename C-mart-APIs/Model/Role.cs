using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace C_mart_APIs.Model
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id{ get; set; }
        public string Name{ get; set; }
        public List<User_Role> User_Roles { get; set; }
    }
}
