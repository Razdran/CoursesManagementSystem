
using System.ComponentModel.DataAnnotations;
using CourseLab.Data.UserManagement;

namespace CourseLab.Web.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}