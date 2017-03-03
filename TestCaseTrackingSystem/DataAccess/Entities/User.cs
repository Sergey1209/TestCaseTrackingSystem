using System;
using System.Collections.Generic;
using DataAccess.Initializers;

namespace DataAccess.Entities
{
    [Initializer(typeof(UserInitializer))]
    public class User
    {
        public int ID { get; set; }
        
        public UserRole Role { get; set; }
        
        public string Login { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }

        public DateTime? LastLogin { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public bool Locked { get; set; }
        
        
        public ICollection<BacklogItem> BacklogItems { get; set; }

        public User()
        {
            BacklogItems = new List<BacklogItem>();
        }
    }
}
