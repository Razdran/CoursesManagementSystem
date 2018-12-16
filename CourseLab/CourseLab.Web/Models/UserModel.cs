using System;
using CourseLab.Data.UserManagement;

namespace CourseLab.Web.Models
{
    public class UserModel
    {
        
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleEnum UserRole { get; set; }
    }
}
