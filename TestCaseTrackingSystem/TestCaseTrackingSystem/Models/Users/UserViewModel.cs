using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccess.Entities;

namespace TestCaseStorage.Models.Users
{
    public class UserViewModel
    {
        public IEnumerable<string> ErrorMessages { get; set; }
        public int ID { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string Skype { get; set; }
        [Range(1, 4)]
        public UserRole Role { get; set; }
        [Range(1, 16)]
        [Required]
        public Position? Position { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLogin { get; set; }
    } 
}