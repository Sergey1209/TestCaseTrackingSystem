using System;
using DataAccess.Entities;
using Services.Interfaces;

namespace Services.DTO
{
    public class UserDto : IDto
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRoleEnum Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
