using CourseLab.Services.Services.Objects.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLab.Web.Models
{
    public class ProfessorRegisterModel : LoginModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Object { get; set; }
        [Required]
        public string Email { get; set; }

        public List<ObjectDto> Objects { get; set; }
    }
}
