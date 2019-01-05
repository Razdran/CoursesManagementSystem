﻿using CourseLab.Data;
using CourseLab.Data.UserManagement;
using CourseLab.Services.Services.Group.Dto;
using System.Collections.Generic;
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
        public string Group { get; set; }
        [Required]
        public YearEnum Year { get; set; }
        [Required]
        public string Email { get; set; }

        public List<GroupDto> Groups { get; set; }
    }
}
