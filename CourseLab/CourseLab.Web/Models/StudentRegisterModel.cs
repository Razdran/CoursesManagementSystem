using CourseLab.Data;
using CourseLab.Data.UserManagement;
using System.ComponentModel.DataAnnotations;

namespace CourseLab.Web.Models
{
    public class StudentRegisterModel : LoginModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public GroupEnum Group { get; set; }
        [Required]
        public YearEnum Year { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
