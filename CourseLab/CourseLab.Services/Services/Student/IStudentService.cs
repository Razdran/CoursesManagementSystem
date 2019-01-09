using CourseLab.Services.Services.Student.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseLab.Services.Services.Student
{
    public interface IStudentService
    {
        List<StudentDto> GetAll();
        StudentDto GetById(Guid id);
        StudentDto GetByUserId(Guid id);
        void CreateStudent(StudentDto studentDto);
        void UpdateStudent(StudentDto StudentDto);
    }
}
