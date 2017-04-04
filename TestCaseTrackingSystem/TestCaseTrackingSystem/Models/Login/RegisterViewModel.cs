using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccess.Entities;

namespace TestCaseStorage.Models.Login
{
    public class RegisterViewModel
    {
        public IEnumerable<string> ErrorMessages { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Email { get; set; }
        public string Skype { get; set; }
        [Required]
        [Range(1, 4)]
        public UserRole Role { get; set; }
        public Position Position { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}