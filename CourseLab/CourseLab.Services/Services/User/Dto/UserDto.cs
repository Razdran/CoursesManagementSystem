using System;
using CourseLab.Data.UserManagement;

namespace CourseLab.Services.Services.User.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleEnum UserRole { get; set; }
        public bool IsDeleted { get; set; }
    }
}
