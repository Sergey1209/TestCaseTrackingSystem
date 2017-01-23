using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int RoleID { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime? LastLogin { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool Locked { get; set; }


        [ForeignKey(nameof(RoleID))]
        public UserRole Role { get; set; }
        
        public ICollection<BacklogItem> AssignedBacklogItems { get; set; }

        public User()
        {
            AssignedBacklogItems = new List<BacklogItem>();
        }
    }
}
