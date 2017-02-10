using System;
using System.ComponentModel.DataAnnotations;
using DataAccess.Entities;

namespace TestCaseStorage.Models.Users
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public UserRoleEnum Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastLoginDate { get; set; }
        

        public string FullName => FirstName + " " + LastName;
    }
}