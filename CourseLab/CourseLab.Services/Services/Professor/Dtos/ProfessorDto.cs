using System;
using System.Collections.Generic;
using System.Text;

namespace CourseLab.Services.Services.Professor.Dtos
{
    public class ProfessorDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid Object { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
    }
}
