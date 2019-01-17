using CourseLab.Data;
using CourseLab.Data.UserManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseLab.Services.Services.Student.Dto
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public Guid UserId { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid Group { get; set; }
        public int Year { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
    }
}
