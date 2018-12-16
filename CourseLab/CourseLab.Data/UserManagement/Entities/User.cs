using System;
namespace CourseLab.Data.UserManagement.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleEnum UserRole { get; set; }
        public bool IsDeleted { get; set; }
    }
}