using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DataAccess.Entities
{
    public class UserRole
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Role { get; set; }

        public IQueryable<User> Users { get; set; }
    }
}