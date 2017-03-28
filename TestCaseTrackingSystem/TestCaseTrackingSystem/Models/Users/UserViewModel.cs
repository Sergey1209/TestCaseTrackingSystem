using System;
using System.Collections.Generic;
using DataAccess.Entities;

namespace TestCaseStorage.Models.Users
{
    public class UserViewModel
    {
        public IEnumerable<string> ErrorMessages { get; set; }
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLogin { get; set; }


        public bool IsNew => ID == 0;
    } 
}