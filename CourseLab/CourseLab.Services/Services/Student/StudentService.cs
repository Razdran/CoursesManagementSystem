using CourseLab.Data.UserManagement.Infrastructure;
using CourseLab.Services.Services.Student.Dto;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities = CourseLab.Data.UserManagement.Entities;

namespace CourseLab.Services.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Entities.Student> studentRepository;
        private readonly IUnitOfWork unitOfWork;

        public StudentService(IRepository<Entities.Student> studentRepository, IUnitOfWork unitOfWork)
        {
            this.studentRepository = studentRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateStudent(StudentDto studentDto)
        {
            studentRepository.Add((Entities.Student)new Entities.Student().InjectFrom(studentDto));
            unitOfWork.Commit();
        }

        

        public List<StudentDto> GetAll()
        {
            var studentList = studentRepository.GetAll();
            var studentDtoList = new List<StudentDto>();
            foreach (var student in studentList)
            {
                var studentDto = (StudentDto)new StudentDto().InjectFrom(student);
                studentDtoList.Add(studentDto);
            }
            return studentDtoList;
        }

        public StudentDto GetById(Guid id)
        {
            var user = studentRepository.GetById(id);
            var userDto = (StudentDto)new StudentDto().InjectFrom(user);

            return userDto;
        }

        public StudentDto GetByUserId(Guid id)
        {
            var user = studentRepository.Query(x => x.UserId == id).SingleOrDefault();
            var userDto = (StudentDto)new StudentDto().InjectFrom(user);

            return userDto;
        }

        public void UpdateStudent(StudentDto studentDto)
        {
            var student = studentRepository.GetById(studentDto.Id);
            var studentDtoUpdate = (StudentDto)new StudentDto().InjectFrom(student);

            studentDtoUpdate.UserId = studentDto.UserId;
            studentDtoUpdate.Group = studentDto.Group;
            studentDtoUpdate.Year = studentDto.Year;
            studentDtoUpdate.Email = studentDto.Email;

            studentRepository.Update((Entities.Student)student.InjectFrom(studentDtoUpdate));
            unitOfWork.Commit();
        }

        
    }
}
