using System;
using System.Collections.Generic;
using System.Text;

namespace CourseLab.Data.UserManagement.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public Guid UserId { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GroupEnum Group { get; set; }
        public YearEnum Year { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }

        public User User { get; set; }
    }
}
