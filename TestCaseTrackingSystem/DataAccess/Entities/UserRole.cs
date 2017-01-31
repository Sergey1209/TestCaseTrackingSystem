using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccess.Initializers;

namespace DataAccess.Entities
{
    [Initializer(typeof(UserRolesInitializer))]
    public class UserRole
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Role { get; set; }

        public ICollection<User> Users { get; set; }
    }
}