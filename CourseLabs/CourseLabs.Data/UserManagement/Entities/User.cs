using System;
namespace CourseLabs.Data.UserManagement.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleEnum UserRole { get; set; }
        public bool IsDeleted { get; set; }
    }
}
